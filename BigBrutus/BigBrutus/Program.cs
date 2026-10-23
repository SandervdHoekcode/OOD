
using BigBrutus.BigBrutus;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace BigBrutus
{
    public class Program
    {
        static void Main(string[] args)
        {
            //campus
            Campus campus = new Campus("CHE");
            CampusManager manager = new CampusManager(campus);

            //gebouwen
            Gebouw alfa = campus.VoegGebouwToe("Alfa");
            Gebouw beta = campus.VoegGebouwToe("Beta");

            //zones
            Zone alfaZoneA = alfa.VoegZoneToe("A");
            Zone alfaZoneB = alfa.VoegZoneToe("B");
            Zone betaZoneA = beta.VoegZoneToe("A");
            Zone betaZoneB = beta.VoegZoneToe("B");

            //hardwarecomponenten
            DimbareLamp lamp = new DimbareLamp("lamp", 60, 80);
            Thermostaat thermostaat = new Thermostaat("thermostaat", 40, 23);
            TemperatuurSensor temperatuursensor = new TemperatuurSensor("TemperatuurSensor");
            EnergieSensor energiesensor = new EnergieSensor("EnergieSensor");
            BewegingsSensor bewegingssensor = new BewegingsSensor("BeweginsSensor");
            Ventilator ventilator = new Ventilator("Ventilator", 40, VentilatorStanden.laag);
            alfaZoneA.VoegComponentToe(lamp);
            betaZoneB.VoegComponentToe(temperatuursensor);
            betaZoneB.VoegComponentToe(thermostaat);
            alfaZoneB.VoegComponentToe(energiesensor);
            betaZoneA.VoegComponentToe(bewegingssensor);
            betaZoneA.VoegComponentToe(ventilator);

            //metingen
            temperatuursensor.RegistreerMeting(21.5);
            energiesensor.RegistreerMeting(44);
            bewegingssensor.RegistreerMeting(0);

            //aan of uit
            lamp.ZetUit();
            thermostaat.ZetAan();
            ventilator.ZetAan();

            //gebeurtenissen
            Gebeurtenis eerste = new Gebeurtenis(Ernstniveau.Informational, "Lamp aangezet");
            System.Threading.Thread.Sleep(50);
            Gebeurtenis tweede = new Gebeurtenis(Ernstniveau.Warning, "Temperatuur hoog");
            System.Threading.Thread.Sleep(50);
            Gebeurtenis derde = new Gebeurtenis(Ernstniveau.Critical, "Sensor offline");

            //regels
            Regel max30 = new Regel(30);
            Regel max50 = new Regel(50);

            try
            {
                Zone zone = alfa.ZoekZone("Z");
                zone.ToonOverzicht();
            }
            catch (ZoneNietGevondenException ex)
            {
                manager.LogGebeurtenis(Ernstniveau.Warning, ex.Message);
            }
            catch (BigBrutusException ex)
            {
                manager.LogGebeurtenis(Ernstniveau.Critical, ex.Message);
            }

            try
            {
                lamp.ZetOffline();
                lamp.ZetAan();
            }
            catch (ApparaatOfflineException ex)
            {
                manager.LogGebeurtenis(Ernstniveau.Warning, ex.Message);
            }
            catch (BigBrutusException ex)
            {
                manager.LogGebeurtenis(Ernstniveau.Critical, ex.Message);
            }
            finally
            {
                lamp.ZetOnline();
                manager.LogGebeurtenis(Ernstniveau.Informational, "Offline-controle afgerond, lamp online gezet");
            }

            try
            {
                thermostaat.Temperatuur = 100;
            }
            catch (GrenswaardeOverschredenException ex)
            {
                manager.LogGebeurtenis(Ernstniveau.Warning, ex.Message);
            }
            catch (BigBrutusException ex)
            {
                manager.LogGebeurtenis(Ernstniveau.Critical, ex.Message);
            }

            manager.ToonLogboek();
        }
    }
}

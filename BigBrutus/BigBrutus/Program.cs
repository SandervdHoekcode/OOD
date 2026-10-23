
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
            BewegingsSensor beweginssensor = new BewegingsSensor("BeweginsSensor");
            Ventilator ventilator = new Ventilator("Ventilator", 40, VentilatorStanden.laag);
            alfaZoneA.VoegComponentToe(lamp);
            betaZoneB.VoegComponentToe(temperatuursensor);
            betaZoneB.VoegComponentToe(thermostaat);
            alfaZoneB.VoegComponentToe(energiesensor);
            betaZoneA.VoegComponentToe(beweginssensor);
            betaZoneA.VoegComponentToe(ventilator);

            //metingen
            temperatuursensor.RegistreerMeting(21.5);
            energiesensor.RegistreerMeting(44);
            beweginssensor.RegistreerMeting(0);

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

            lamp.ZetOffline();
            try
            {
                lamp.ZetAan();
            }
            catch (ApparaatOfflineException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}

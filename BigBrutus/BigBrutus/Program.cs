
using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace BigBrutus
{
    public class Program
    {
        static void Main(string[] args)
        {
            Campus campus = new Campus("CHE");
            CampusManager manager = new CampusManager(campus);

            Gebouw alfa = campus.VoegGebouwToe("Alfa");
            Gebouw beta = campus.VoegGebouwToe("Beta");

            Zone alfaZoneA = alfa.VoegZoneToe("A");
            Zone alfaZoneB = alfa.VoegZoneToe("B");
            Zone betaZoneA = beta.VoegZoneToe("A");
            Zone betaZoneB = beta.VoegZoneToe("B");

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
            temperatuursensor.RegistreerMeting(21.5);
            energiesensor.RegistreerMeting(44);
            beweginssensor.RegistreerMeting(0);
            lamp.ZetUit();
            thermostaat.ZetAan();
            ventilator.ZetAan();

            campus.ToonOverzicht();
            Console.WriteLine("Totaalberekeing:");
            Console.WriteLine(manager.BerekenTotaalEnergieverbruik());
            manager.RunCampusDiagnose();
            
            manager.ZetAlleApparatenUit();
            Console.WriteLine(manager.BerekenTotaalEnergieverbruik());

            Logboek<Gebeurtenis> logboek = new Logboek<Gebeurtenis>();

            Gebeurtenis eerste = new Gebeurtenis(Ernstniveau.Informational, "Lamp aangezet");
            System.Threading.Thread.Sleep(50);
            Gebeurtenis tweede = new Gebeurtenis(Ernstniveau.Warning, "Temperatuur hoog");
            System.Threading.Thread.Sleep(50);
            Gebeurtenis derde = new Gebeurtenis(Ernstniveau.Critical, "Sensor offline");

            // bewust in een andere volgorde toegevoegd
            logboek.VoegGebeurtenisToe(derde);
            logboek.VoegGebeurtenisToe(eerste);
            logboek.VoegGebeurtenisToe(tweede);

            List<Gebeurtenis> overzicht = logboek.ChronologischOverzicht();

            foreach (Gebeurtenis g in overzicht)
            {
                Console.WriteLine($"{g.Tijd:HH:mm:ss.fff} - {g.Ernst}: {g.Omschrijving}");
            }

            temperatuursensor.RegistreerMeting(40);
            Regel max30 = new Regel(30);
            Regel max50 = new Regel(50);
            Console.WriteLine($"Grens 30: {max30.Controleer(temperatuursensor)}");
            Console.WriteLine($"Grens 50: {max50.Controleer(temperatuursensor)}");

            beweginssensor.RegistreerMeting(1);
            Console.WriteLine($"Beweging: {max30.Controleer(beweginssensor)}");
        }
    }
}

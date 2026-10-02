
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
            Ventilator ventilator = new Ventilator("Ventilator", 35);
            alfaZoneA.VoegApparaatToe(lamp);
            betaZoneB.VoegSensorToe(temperatuursensor);
            betaZoneB.VoegApparaatToe(thermostaat);
            alfaZoneB.VoegSensorToe(energiesensor);
            betaZoneA.VoegSensorToe(beweginssensor);
            betaZoneA.VoegApparaatToe(ventilator);
            temperatuursensor.RegistreerMeting(21.5);
            lamp.ZetAan();
            Console.WriteLine(lamp.IsAan);
            new Gebeurtenis(Ernstniveau.Warning, "Temperatuur te hoog");

            campus.ToonOverzicht();
        }
    }
}

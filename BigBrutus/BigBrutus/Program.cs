
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
            Sensor temperatuursensor = new Sensor("TemperatuurSensor");
            alfaZoneA.VoegApparaatToe(lamp);
            betaZoneB.VoegSensorToe(temperatuursensor);
            betaZoneB.VoegApparaatToe(thermostaat);
            temperatuursensor.RegistreerMeting(21.5);
            lamp.ZetAan();
            Console.WriteLine(lamp.IsAan);

            campus.ToonOverzicht();



        }
    }
}

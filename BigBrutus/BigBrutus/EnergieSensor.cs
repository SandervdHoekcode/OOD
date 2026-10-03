namespace BigBrutus
{
    public class EnergieSensor : Sensor
    {
        public EnergieSensor(string naam) : base(naam) { }

        public override string VoerDiagnoseUit()
        {
            return $"{Naam}: in orde";
        }
    }
}
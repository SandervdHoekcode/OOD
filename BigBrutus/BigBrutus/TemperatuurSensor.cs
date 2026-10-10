using System;
using System.Collections.Generic;
using System.Text;

namespace BigBrutus
{
    public class TemperatuurSensor : Sensor
    {
        public TemperatuurSensor(string naam) : base(naam) { }


        public override string VoerDiagnoseUit()
        {
            return $"{Naam} meet een waarde van {Meetwaarde}°C";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace BigBrutus
{
    public class BewegingsSensor : Sensor
    {
        public BewegingsSensor(string naam) : base(naam) { }


        public override string VoerDiagnoseUit()
        {
            return $"{Naam}: in orde";
        }
    } 
}
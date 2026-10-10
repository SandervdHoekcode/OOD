using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BigBrutus
{
    public class BewegingsSensor : Sensor
    {
        public BewegingsSensor(string naam) : base(naam) { }


        public override string VoerDiagnoseUit()
        {
            string beweging;

            if (Meetwaarde == 0)
                beweging = "geen";
            else
                beweging = "wel";
            return $"{Naam}: heeft {beweging} beweging opgemerkt";
        }
    } 
}
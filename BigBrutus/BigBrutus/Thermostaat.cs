using System;
using System.Collections.Generic;
using System.Text;

namespace BigBrutus
{
    public class Thermostaat : Apparaat
    {
        private double temperatuur;
        public double Temperatuur
        {
            get
            {
                return temperatuur;
            }
            set
            {
                if (value < -20 || value > 60)
                {
                    throw new ArgumentException("Temperatuur moet tussen -20 en 60 graden zijn");
                }
                temperatuur = value;
            }
        }
        public Thermostaat (string naam, double vermogen, double temperatuur) : base(naam, vermogen)
        {
            Temperatuur = temperatuur;
        }
    }
}

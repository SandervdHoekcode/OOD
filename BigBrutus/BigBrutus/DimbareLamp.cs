using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BigBrutus
{

    public class DimbareLamp : Apparaat
    {
        private int helderheid;
        public int Helderheid
        {
            get
            {
                return helderheid;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Helderheid moet tussen 0 en 100 zijn");
                }
                helderheid = value;
            }
        }
        public DimbareLamp(string naam, double vermogen, int helderheid) : base(naam, vermogen)
        {
            Helderheid = helderheid;
        }
    }
}


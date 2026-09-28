using System;
using System.Collections.Generic;
using System.Text;

namespace BigBrutus
{
    public class Sensor
    {
        public string Naam { get; private set; }
        public double Meetwaarde { get; private set; }

        public Sensor(string naam, double meetwaarde)
        {
            Naam = naam;
        }

        public void RegistreerMeting(double waarde)
        {
            Meetwaarde = waarde;

        }
    }
}

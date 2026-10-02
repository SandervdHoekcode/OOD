using System;
using System.Collections.Generic;
using System.Text;

namespace BigBrutus
{
    public abstract class Sensor : HardwareComponent
    {
        public double Meetwaarde { get; private set; }

        public Sensor(string naam) : base(naam) { }

        public void RegistreerMeting(double waarde)
        {
            Meetwaarde = waarde;

        }
    }
}

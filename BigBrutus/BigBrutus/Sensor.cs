using System;
using System.Collections.Generic;
using System.Text;

namespace BigBrutus
{
    public abstract class Sensor : HardwareComponent, IAlertbaar
    {
        public double Meetwaarde { get; private set; }

        public Sensor(string naam) : base(naam) { }

        public void RegistreerMeting(double waarde)
        {
            Meetwaarde = waarde;

        }

        public virtual bool IsInAlarm(double grenswaarde)
        {
            if (Meetwaarde > grenswaarde )
                return true;
            else
                return false;
        }
    }
}

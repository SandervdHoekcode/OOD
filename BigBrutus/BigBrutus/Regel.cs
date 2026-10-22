using System;
using System.Collections.Generic;
using System.Text;

namespace BigBrutus
{
    public class Regel
    {
        public double Grenswaarde { get; }

        public Regel(double grenswaarde)
        {
            Grenswaarde = grenswaarde;
        }

        public bool Controleer(IAlertbaar component)
        {
            return component.IsInAlarm (Grenswaarde);
        }
    }
}

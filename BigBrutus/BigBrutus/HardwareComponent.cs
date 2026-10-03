using System;
using System.Collections.Generic;
using System.Text;

namespace BigBrutus
{
    public abstract class HardwareComponent
    {
        public string Naam { get; private set; }

        public HardwareComponent(string naam)
        {
            Naam = naam;
        }
        public abstract string VoerDiagnoseUit();
        public virtual double BerekenHuidigVerbruik() { return 0; }
    }
}

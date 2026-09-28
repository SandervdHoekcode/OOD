using System;
using System.Collections.Generic;
using System.Text;

namespace BigBrutus
{

    public class Apparaat
    {
        public string Naam { get; private set; }
        public double Vermogen { get; private set; }
        public bool IsAan { get; private set; }

    public Apparaat (string naam, double vermogen)
        {
            Naam = naam;
            Vermogen = vermogen;
        }
    public void ZetAan()
        {
            IsAan = true;
        }
    public void ZetUit()
        {
            IsAan = false;
        }    
    }

}

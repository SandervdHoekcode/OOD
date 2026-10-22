using System;
using System.Collections.Generic;
using System.Text;

namespace BigBrutus
{

    public abstract class Apparaat : HardwareComponent, IAanstuurbaar, IEnergieverbruiker
    {
        public double Vermogen { get; private set; }
        public bool IsAan { get; private set; }

    public Apparaat (string naam, double vermogen) : base (naam)
        {
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

using System;
using System.Collections.Generic;
using System.Text;

namespace BigBrutus
{

    public abstract class Apparaat : HardwareComponent, IAanstuurbaar, IEnergieverbruiker
    {
        public double Vermogen { get; private set; }
        public bool IsAan { get; private set; }
        public bool IsOnline { get; private set; }

        public Apparaat(string naam, double vermogen) : base(naam)
        {
            Vermogen = vermogen;
            IsOnline = true;
        }
        public void ZetAan()
        {
            if (IsOnline == false)
            throw new ApparaatOfflineException(Naam);
            
            IsAan = true;
        }
        public void ZetUit()
        {
            IsAan = false;
        }

        public void ZetOffline()
        {
            IsOnline = false;
        }

        public void ZetOnline()
        {
            IsOnline = true;
        }
    }
}

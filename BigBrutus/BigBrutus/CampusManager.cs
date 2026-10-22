using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BigBrutus
{
    public class CampusManager
    {
        private Campus campus;

        public CampusManager(Campus campus)
        {
            this.campus = campus;
        }

        public double BerekenTotaalEnergieverbruik()
        {
            double totaal = 0;

            foreach (HardwareComponent component in campus.AlleComponents().OfType<IEnergieverbruiker>())
            {
                totaal += component.BerekenHuidigVerbruik();
            }

            return totaal;
        }

        public void RunCampusDiagnose()
        {
            foreach (HardwareComponent component in campus.AlleComponents())
            {
                Console.WriteLine(component.VoerDiagnoseUit());
            }
        }

        public void ZetAlleApparatenUit()
        {
            foreach (IAanstuurbaar apparaat in campus.AlleComponents().OfType<IAanstuurbaar>())
            {
                apparaat.ZetUit();
            }
        }

    }
}

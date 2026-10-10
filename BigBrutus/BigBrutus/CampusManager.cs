using System;
using System.Collections.Generic;
using System.Text;

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

            foreach (HardwareComponent component in campus.AlleComponents())
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

    }
}

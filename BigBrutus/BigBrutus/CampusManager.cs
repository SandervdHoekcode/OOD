using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.VisualBasic;
using System.ComponentModel;

namespace BigBrutus
{
    public class CampusManager
    {
        private Campus campus;
        private Logboek<Gebeurtenis> logboek;

        public CampusManager(Campus campus)
        {
            this.campus = campus;
            logboek = new Logboek<Gebeurtenis>();
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

        public void LogGebeurtenis(Ernstniveau ernst, string omschrijving)
        {
            Gebeurtenis gebeurtenis = new Gebeurtenis(ernst, omschrijving);
            logboek.VoegGebeurtenisToe(gebeurtenis);
        }

        public void ToonLogboek()
        {
            logboek.ToonOverzicht();
        }

    }
}

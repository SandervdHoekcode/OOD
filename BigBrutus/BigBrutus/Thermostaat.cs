using System;
using System.Collections.Generic;
using System.Text;

namespace BigBrutus
{
    public class Thermostaat : Apparaat
    {
        private double temperatuur;
        public double Temperatuur
        {
            get
            {
                return temperatuur;
            }
            set
            {
                if (value < -20 || value > 60)
                {
                    throw new GrenswaardeOverschredenException(Naam);
                }
                temperatuur = value;
            }
        }
        public Thermostaat(string naam, double vermogen, double temperatuur) : base(naam, vermogen)
        {
            Temperatuur = temperatuur;
        }

        public override double BerekenHuidigVerbruik()
        {
            if (IsAan == false)
                return 0;
            else
            {
                return 40;
            }
        }
        public override string VoerDiagnoseUit()
        {
            string status;

            if (IsAan == true)
                status = "aan";
            else
                status = "uit";

            return $"{Naam} staat {status}, de temperatuur is {Temperatuur}, het vermogen is {BerekenHuidigVerbruik()}";
        }
    }
}

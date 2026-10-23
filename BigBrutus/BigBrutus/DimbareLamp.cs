using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BigBrutus
{

    public class DimbareLamp : Apparaat
    {
        private int helderheid;
        public int Helderheid
        {
            get
            {
                return helderheid;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new GrenswaardeOverschredenException(Naam);
                }
                helderheid = value;
            }
        }
        public DimbareLamp(string naam, double vermogen, int helderheid) : base(naam, vermogen)
        {
            Helderheid = helderheid;
        }
        public override double BerekenHuidigVerbruik()
        {
            if (IsAan == false)
                return 0;
            else
            {
                return Vermogen * Helderheid / 100.0;
            }
        }
        public override string VoerDiagnoseUit()
        {
            string status;

            if (IsAan == true)
                status = "aan";
            else
                status = "uit";

            return $"{Naam} staat {status} met een helderheid van {Helderheid} en een vermogen van {BerekenHuidigVerbruik()}";
        }
    }
}


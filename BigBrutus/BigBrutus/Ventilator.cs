using BigBrutus.BigBrutus;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace BigBrutus
{
    public class Ventilator : Apparaat
    {
        public VentilatorStanden Stand { get; private set; }
        public Ventilator(string naam, double vermogen, VentilatorStanden standen) : base(naam, vermogen) 
        {
            Stand = standen;
        }

        public override double BerekenHuidigVerbruik()
        {
            if (IsAan == false)
            {
                return 0;
            }

            switch (Stand)
            {
                case VentilatorStanden.laag:
                    return Vermogen / 3;
                case VentilatorStanden.midden:
                    return Vermogen / 3 * 2;
                case VentilatorStanden.hoog:
                    return Vermogen / 3 * 3;
                default:
                    throw new BigBrutusException($"Onbekende stand {Stand} voor {Naam}");
            }
        }

        public override string VoerDiagnoseUit()
        {
            string status;

            if (IsAan == true)
                status = "aan";
            else
                status = "uit";
            return $"{Naam} staat {status} op het stand van {Stand} waardoor hij een gebruik heeft van {BerekenHuidigVerbruik()}";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace BigBrutus
{
    public class Gebouw
    {
        public string Naam { get; private set; }
        private List<Zone> zones = new List<Zone>();

        public Gebouw(string naam)
        {
            Naam = naam;
        }

        public void VoegZoneToe(string naam)
        {
            Zone nieuw = new Zone(naam);
            zones.Add(nieuw);
        }
    }
}

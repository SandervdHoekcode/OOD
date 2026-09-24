using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace BigBrutus
{
    public class Campus
    {
        public string Naam {  get; private set;  }

        private List<Gebouw> gebouwen = new List<Gebouw>();

        public Campus(string naam)
        {
            Naam = naam;
        }
        public Gebouw VoegGebouwToe(string naam)
        {
            Gebouw nieuw = new Gebouw(naam);
            gebouwen.Add(nieuw);
            return nieuw;
        }
    }
}

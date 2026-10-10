using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace BigBrutus
{
    public class Campus
    {
        public string Naam { get; private set; }

        public List<Gebouw> gebouwen = new List<Gebouw>();

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

        public void ToonOverzicht()
        {
            Console.WriteLine(Naam);
            foreach (Gebouw gebouw in gebouwen)
            {
                gebouw.ToonOverzicht();
            }
        }

        public List<HardwareComponent> AlleComponents()
        {
            List<HardwareComponent> allcomplist = new List<HardwareComponent>();

            foreach (Gebouw gebouw in gebouwen)
            {
                allcomplist.AddRange(gebouw.Doorgeven());
            }
            return allcomplist;
        }
                
    }
}

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
        // 1. Print de naam van de campus
        // 2. Loop door alle gebouwen in de lijst
        //    3. Print per gebouw zijn naam

        public void ToonOverzicht()
        {
            Console.WriteLine(Naam);
            foreach (Gebouw gebouw in gebouwen)
            {
                Console.WriteLine(gebouw.Naam);
            }
        }
                
    }
}

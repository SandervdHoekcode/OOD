
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace BigBrutus
{
    public class Program
    {
        // 1. Maak een campus aan en bewaar hem in een variabele
        // 2. Voeg via de campus een gebouw "Alfa" toe en bewaar het teruggegeven gebouw
        // 3. Voeg via de campus een gebouw "Beta" toe en bewaar het
        // 4. Voeg via gebouw Alfa twee zones toe
        // 5. Voeg via gebouw Beta één zone toe
        // 6. Laat de campus zijn overzicht printen



        static void Main(string[] args)
        {
            Campus campus = new Campus("CHE");


            campus.VoegGebouwToe("Alfa");
            Gebouw Alfa = new Gebouw("Alfa");
            campus.VoegGebouwToe("Beta");
            Gebouw Beta = new Gebouw("Beta");

            Alfa.VoegZoneToe("A");            
            Alfa.VoegZoneToe("B");
            Zone A_A = new Zone("A");
            Zone A_B = new Zone("B");
            Beta.VoegZoneToe("A");
            Beta.VoegZoneToe("B");
            Zone B_A = new Zone("A");
            Zone B_B = new Zone("B");

            campus.ToonOverzicht();
        
        }
    }
}

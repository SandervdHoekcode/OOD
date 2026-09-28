using System;
using System.Collections.Generic;
using System.Text;

namespace BigBrutus
{
    public class Zone
    {
        public string Naam { get; private set; }

        public Zone(string naam)
        {
            Naam = naam;
        }
        public List<Apparaat> apparaten = new List<Apparaat>();
        public List<Sensor> sensoren = new List<Sensor>();

        public void VoegApparaatToe(Apparaat apparaat)
        {
            apparaten.Add(apparaat);
        }
        public void VoegSensorToe(Sensor sensor)
        {
            sensoren.Add(sensor); 
        }
       
    }
}   

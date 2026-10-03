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
        public List<HardwareComponent> hardwarecomponents = new List<HardwareComponent>();

        public void VoegComponentToe (HardwareComponent component)
        {
            hardwarecomponents.Add(component);
        }
       
    }
}   

using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public void ToonOverzicht()
        {
            Console.WriteLine($"zone: {Naam}");
            foreach (HardwareComponent component in hardwarecomponents)
            {
                Console.WriteLine(component.Naam);
            }
        }
       
    }
}   

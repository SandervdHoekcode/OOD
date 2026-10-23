using BigBrutus.BigBrutus;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigBrutus
{
    public class ZoneNietGevondenException : BigBrutusException
    {
        public ZoneNietGevondenException(string zoneNaam)
            : base($"Zone {zoneNaam} niet gevonden, probeer een andere zonenaam") { }
    }
}

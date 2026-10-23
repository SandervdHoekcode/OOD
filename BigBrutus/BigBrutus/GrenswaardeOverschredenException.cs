using BigBrutus.BigBrutus;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigBrutus
{
    public class GrenswaardeOverschredenException : BigBrutusException
    {
        public GrenswaardeOverschredenException(string apparaatNaam)
            : base($"de waarde van {apparaatNaam} is niet mogelijk, zorgt dat de waarde binnen de gebruikelijke eenheden valt") { }
    }
}

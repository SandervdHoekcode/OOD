using BigBrutus.BigBrutus;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigBrutus
{
    public class ApparaatOfflineException : BigBrutusException
    {
        public ApparaatOfflineException(string apparaatNaam)
            : base($"{apparaatNaam} is offline, controleer de connectie") { }
    }
}

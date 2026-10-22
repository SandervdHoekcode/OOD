using System;
using System.Collections.Generic;
using System.Text;

namespace BigBrutus
{
    public interface IAlertbaar
    {
        bool IsInAlarm(double grenswaarde);
    }
}

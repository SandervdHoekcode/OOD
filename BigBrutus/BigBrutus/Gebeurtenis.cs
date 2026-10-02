using BigBrutus;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
public class Gebeurtenis
{
    public Ernstniveau Ernst { get; private set; }
    public DateTime Tijd { get; private set; }
    public string Omschrijving { get; private set; }

    public Gebeurtenis(Ernstniveau ernst, string omschrijving)
    {
        Ernst = ernst;
        Tijd = DateTime.Now;
        Omschrijving = omschrijving;
    }


}
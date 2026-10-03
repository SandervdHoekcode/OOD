using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace BigBrutus
{
    public class Logboek<T> where T : Gebeurtenis
    {
        private List<T> gebeurtenissen = new List<T>();

        public void VoegGebeurtenisToe(T gebeurtenis)
        {
            gebeurtenissen.Add(gebeurtenis);
        }
        public List<T> FilterOpErnst(Ernstniveau ernst)
        {
            List<T> resultaat = new List<T>();

            foreach (T item in gebeurtenissen)
            {
                if (item.Ernst == ernst)
                {
                    resultaat.Add(item);
                }
            }

            return resultaat;
        }

        public List<T> ChronologischOverzicht()
        {
            return gebeurtenissen.OrderBy(item => item.Tijd).ToList();
        }
    }
}

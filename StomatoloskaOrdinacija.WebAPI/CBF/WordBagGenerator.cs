using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StomatoloskaOrdinacija.Model;

namespace StomatoloskaOrdinacija.WebAPI.CBF
{
    public class WordBagGenerator
    {
        public string GenerateWordBag<T>(object item)
        {
            if (typeof(T) == typeof(Usluga))
            {
                var eventObj = item as Usluga;
                string wordBag = eventObj.Cijena + "_" + eventObj.Naziv.ToLower();
                return wordBag;
            }
            return String.Empty;
        }

    }
}

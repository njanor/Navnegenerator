using System;
using System.Collections.Generic;
using System.Linq;
using Navnegenerator.Typar.Exceptions;

namespace Navnegenerator.Typar
{
    public class Navneoversikt
    {
        private Random random = new Random();
        private int totaltAntallTal;
        private readonly SortedDictionary<int, string> navn = new SortedDictionary<int, string>();

        public void LeggTilNavn(string navn, int antall)
        {
            this.navn.Add(totaltAntallTal, navn);
            totaltAntallTal += antall;
        }

        public IEnumerable<string> HentAlleNavn()
        {
            return navn.Values;
        }

        public string HentEitNyttTilfeldigNavn()
        {
            if (navn.Count == 0)
                throw new NavnegeneratorException("Kan ikkje generera eit navn når oversikta ikkje har navn.");
            var navnenummer = random.Next(totaltAntallTal);
            return navn.Last(x => x.Key <= navnenummer).Value;
        }
    }
}
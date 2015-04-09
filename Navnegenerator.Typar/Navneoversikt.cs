using System.Collections.Generic;

namespace Navnegenerator.Typar
{
    public class Navneoversikt
    {
        private int totaltAntallTal;
        private readonly SortedDictionary<int, string> navna = new SortedDictionary<int, string>();

        public void LeggTilNavn(string navn, int antall)
        {
            navna.Add(totaltAntallTal, navn);
            totaltAntallTal += antall;
        }

        public IEnumerable<string> HentAlleEtternavn()
        {
            return navna.Values;
        }
    }
}
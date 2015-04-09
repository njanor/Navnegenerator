using System.IO;
using System.Linq;
using CsvHelper;
using Navnegenerator.Typar;

namespace Navnegenerator.Navneverktøy
{
    public static class EtternavnParser
    {
        public static Navneoversikt ParseEtternavn(StreamReader etternavnReader)
        {
            var csv = new CsvReader(etternavnReader);
            csv.Configuration.Delimiter = ";";
            var records = csv.GetRecords<EtternavnFraCSV>().ToList();
            var navneoversikt = new Navneoversikt();
            records.ToList().ForEach(r => navneoversikt.LeggTilNavn(r.Navn, r.Antall));
            return navneoversikt;
        }
    }
}
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using Navnegenerator.Navneverktøy.Støttetypar;
using Navnegenerator.Typar;

namespace Navnegenerator.Navneverktøy
{
    public static class NavneParser
    {
        public static Navneoversikt ParseEtternavn(StreamReader etternavnReader)
        {
            return LagNavneoversikt<EtternavnFråCSV>(etternavnReader);
        }

        public static Navneoversikt ParseFornavn(StreamReader fornavnReader)
        {
            return LagNavneoversikt<FornavnFråCSV>(fornavnReader);
        }

        private static Navneoversikt LagNavneoversikt<T>(StreamReader navnReader) where T : NavnFråCSV
        {
            var navn = HentNavn<T>(navnReader).ToList();
            return LagNavneoversiktFråNavn(navn);
        }

        private static Navneoversikt LagNavneoversiktFråNavn<T>(IEnumerable<T> navn) where T : NavnFråCSV
        {
            var navneoversikt = new Navneoversikt();
            navn.ToList().ForEach(r => navneoversikt.LeggTilNavn(r.Navn, r.Antal));
            return navneoversikt;
        }

        private static IEnumerable<T> HentNavn<T>(StreamReader navnReader) where T : NavnFråCSV
        {
            var csv = HentCsvReader<T>(navnReader);
            var records = csv.GetRecords<T>();
            return records;
        }

        private static CsvReader HentCsvReader<T>(StreamReader navnReader) where T : NavnFråCSV
        {
            var csv = new CsvReader(navnReader);
            csv.Configuration.Delimiter = ";";
            csv.Configuration.RegisterClassMap<EtternavnFråCSVMapping>();
            csv.Configuration.RegisterClassMap<FornavnFråCsvMapper>();
            return csv;
        }
    }
}
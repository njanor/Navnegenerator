using CsvHelper.Configuration;

namespace Navnegenerator.Navneverktøy.Støttetypar
{
    internal class EtternavnFråCSV : NavnFråCSV
    {
        public int Nummer { get; set; }
        public string Navn { get; set; }
        public int Antal { get; set; }
    }

    internal class EtternavnFråCSVMapping : ClassMap<EtternavnFråCSV>
    {
        public EtternavnFråCSVMapping()
        {
            Map(e => e.Navn);
            Map(e => e.Navn);
            Map(e => e.Antal).Name("Antall").TypeConverter<SSBCSVStringToIntConverter>();
        }
    }
}
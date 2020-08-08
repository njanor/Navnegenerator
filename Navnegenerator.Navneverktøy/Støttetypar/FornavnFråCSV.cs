using CsvHelper.Configuration;

namespace Navnegenerator.Navneverktøy.Støttetypar
{
    internal class FornavnFråCSV : NavnFråCSV
    {
        public string Navn { get; set; }
        public int Antal { get; set; }
        public string Gamal1 { get; set; }
        public string Gamal2 { get; set; }
        public string Gamal3 { get; set; }
        public string Gamal4 { get; set; }
        public string Gamal5 { get; set; }
        public string Gamal6 { get; set; }
        public string Gamal7 { get; set; }
        public string Gamal8 { get; set; }
        public string Gamal9 { get; set; }
    }

    internal class FornavnFråCsvMapper : ClassMap<FornavnFråCSV>
    {
        public FornavnFråCsvMapper()
        {
            Map(f => f.Navn).Index(0);
            Map(f => f.Antal).Index(1).TypeConverter<SSBCSVStringToIntConverter>();
            Map(f => f.Gamal1).Index(2);
            Map(f => f.Gamal2).Index(3);
            Map(f => f.Gamal3).Index(4);
            Map(f => f.Gamal4).Index(5);
            Map(f => f.Gamal5).Index(6);
            Map(f => f.Gamal6).Index(7);
            Map(f => f.Gamal7).Index(8);
            Map(f => f.Gamal8).Index(9);
            Map(f => f.Gamal9).Index(10);
        }
    }
}
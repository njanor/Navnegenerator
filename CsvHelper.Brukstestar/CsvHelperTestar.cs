using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper.Configuration;
using NUnit.Framework;
using Shouldly;

namespace CsvHelper.Brukstestar
{
    public class CsvHelperTestar
    {
        [Test]
        public void CsvHelperBruk_SettSemikolonSomSkiljeteikn_LastarRecordsRett()
        {
            using( var stream = new MemoryStream() )
			using( var reader = new StreamReader( stream ) )
			using( var writer = new StreamWriter( stream ) )
			using (var csv = new CsvReader(reader, new CultureInfo("nn-NO")))
			{
                writer.WriteLine("Nummer;Tekst;");
                writer.WriteLine("1;Ein;");
                writer.WriteLine("2;To;");
                writer.Flush();

			    stream.Position = 0;

			    csv.Configuration.Delimiter = ";";
			    var records = csv.GetRecords<Simpel>().ToList();
                
                records.Count().ShouldBe(2);
                records.First().Nummer.ShouldBe(1);
                records.First().Tekst.ShouldBe("Ein");
			}
        }

        [Test]
        public void CsvHelperBruk_MappingMotKolonneUtanNavn_FungererMedManuellMapping()
        {
            using( var stream = new MemoryStream() )
			using( var reader = new StreamReader( stream ) )
			using( var writer = new StreamWriter( stream ) )
			using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
			{
                writer.WriteLine(" ,Tekst,");
                writer.WriteLine("1,Ein,");
                writer.Flush();
			    stream.Position = 0;

                csv.Configuration.RegisterClassMap<SimpelMapManglandeKolonnenavn>();
			    var records = csv.GetRecords<Simpel>().ToList();

                records.Count().ShouldBe(1);
                records.First().Nummer.ShouldBe(1);
                records.First().Tekst.ShouldBe("Ein");
			}
        }

        private class SimpelMapManglandeKolonnenavn : ClassMap<Simpel>
        {
            public SimpelMapManglandeKolonnenavn()
            {
                Map(s => s.Nummer).Index(0);
                Map(s => s.Tekst).Name("Tekst");
            }
        }

        private class Simpel
        {
            public int Nummer { get; set; }
            public string Tekst { get; set; }
        }
    }
}

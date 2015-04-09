using System.IO;
using System.Linq;
using NUnit.Framework;
using Shouldly;

namespace CsvHelper.Brukstestar
{
    public class CsvHelperTestar
    {
        [Test]
        public void TestAtEtternavnParserKanLagaEiNavneoversikt()
        {
            using( var stream = new MemoryStream() )
			using( var reader = new StreamReader( stream ) )
			using( var writer = new StreamWriter( stream ) )
			using (var csv = new CsvReader(reader))
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

        private class Simpel
        {
            public int Nummer { get; set; }
            public string Tekst { get; set; }
        }
    }
}

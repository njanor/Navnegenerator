using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Shouldly;

namespace Navnegenerator.Navneverktøy.Testar
{
    public class EtternavnParserTestar
    {
        [Test]
        public void ParsingAvEtternavn_GyldigFormat_ReturnererGyldigOversikt()
        {
            using( var stream = new MemoryStream() )
			using( var reader = new StreamReader( stream ) )
			using (var writer = new StreamWriter(stream))
			{
                writer.WriteLine("Nummer;Navn;Antall;");
                writer.WriteLine("1;Hansen;3;");
                writer.WriteLine("2;Johansen;1;");
                writer.Flush();
			    stream.Position = 0;

			    var etternavnsoversikt = NavneParser.ParseEtternavn(reader);

			    etternavnsoversikt.HentAlleNavn().Count().ShouldBe(2);
			    etternavnsoversikt.HentAlleNavn().ShouldContain("Hansen");
			    etternavnsoversikt.HentAlleNavn().ShouldContain("Johansen");
			}
        }

        [Test]
        public void ParsingAvEtternavn_ManglandeTittellinja_SkalFeila()
        {
            using( var stream = new MemoryStream() )
			using( var reader = new StreamReader( stream ) )
			using (var writer = new StreamWriter(stream))
			{
                writer.WriteLine("1;Hansen;3;");
                writer.WriteLine("2;Johansen;1;");
                writer.Flush();
                stream.Position = 0;

                Should.Throw<Exception>(() => NavneParser.ParseEtternavn(reader));
			}
        }
    }
}
using System.IO;
using System.Linq;
using NUnit.Framework;
using Shouldly;

namespace Navnegenerator.Navneverktøy.Testar
{
    public class FornavnParserTestar
    {
        [Test]
        public void ParsingAvFornavn_GyldigFormat_ReturnererGyldigOversikt()
        {
            using( var stream = new MemoryStream() )
			using( var reader = new StreamReader( stream ) )
			using (var writer = new StreamWriter(stream))
			{
                writer.WriteLine(" ;2014;2013;2012;2011;2010;2009;2008;2007;2006;2005;");
                writer.WriteLine("Abigail;9;16;17;6;10;10;8;8;4;:;");
                writer.WriteLine("Ada;108;128;128;109;95;99;91;101;71;76;");
                writer.Flush();
			    stream.Position = 0;

			    var navneoversikt = NavneParser.ParseFornavn(reader);

			    navneoversikt.HentAlleNavn().Count().ShouldBe(2);
                navneoversikt.HentAlleNavn().ShouldContain("Ada");
			}
        }
    }
}
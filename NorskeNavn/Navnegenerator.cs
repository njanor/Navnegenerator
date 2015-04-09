using System.IO;
using System.Reflection;
using Navnegenerator.Navneverktøy;
using Navnegenerator.Typar;

namespace NorskeNavn
{
    public class Navnegenerator
    {
        private Navneoversikt fornavnsoversikt;
        private Navneoversikt etternavnsoversikt;

        public Navnegenerator()
        {
            etternavnsoversikt = NavneParser.ParseEtternavn(HentReader("NorskeNavn.Resources.etternavn.csv"));
            fornavnsoversikt = NavneParser.ParseFornavn(HentReader("NorskeNavn.Resources.jentenavn.csv"));
        }

        private static StreamReader HentReader(string etternavncsv)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var navneReader = new StreamReader(assembly.GetManifestResourceStream(etternavncsv));
            return navneReader;
        }

        public Navn GenererNyttNavn()
        {
            return new Navn(fornavnsoversikt.HentEitNyttTilfeldigNavn(), etternavnsoversikt.HentEitNyttTilfeldigNavn());
        }
    }
}
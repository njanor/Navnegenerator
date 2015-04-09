using System.IO;
using System.Reflection;
using Navnegenerator.Navneverktøy;
using Navnegenerator.Typar;

namespace NorskeNavn
{
    public class Navnegenerator
    {
        private Navneoversikt etternavnsoversikt;

        public Navnegenerator()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var etternavnReader = new StreamReader(assembly.GetManifestResourceStream("NorskeNavn.Resources.etternavn.csv"));
            etternavnsoversikt = EtternavnParser.ParseEtternavn(etternavnReader);
        }

        public Navn GenererNyttNavn()
        {
            return new Navn(null, etternavnsoversikt.HentEitNyttTilfeldigNavn());
        }
    }
}
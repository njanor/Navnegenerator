using System;
using System.IO;
using System.Reflection;
using Navnegenerator.Navneverktøy;
using Navnegenerator.Typar;

namespace NorskeNavn
{
    public class Generator
    {
        private readonly Random random;
        private readonly Navneoversikt etternavnsoversikt;
        private readonly Navneoversikt kvinnenavnsoversikt;
        private readonly Navneoversikt herrenavnsoversikt;

        public Generator()
        {
            random = new Random();
            etternavnsoversikt = NavneParser.ParseEtternavn(HentReader("NorskeNavn.Resources.etternavn.csv"));
            kvinnenavnsoversikt = NavneParser.ParseFornavn(HentReader("NorskeNavn.Resources.jentenavn.csv"));
            herrenavnsoversikt = NavneParser.ParseFornavn(HentReader("NorskeNavn.Resources.gutenavn.csv"));
        }

        public Generator(int seed)
        {
            random = new Random(seed);
            etternavnsoversikt = NavneParser.ParseEtternavn(HentReader("NorskeNavn.Resources.etternavn.csv"));
            kvinnenavnsoversikt = NavneParser.ParseFornavn(HentReader("NorskeNavn.Resources.jentenavn.csv"));
            herrenavnsoversikt = NavneParser.ParseFornavn(HentReader("NorskeNavn.Resources.gutenavn.csv"));
        }

        private Navneoversikt Navneoversikt
        {
            get
            {
                if (random.Next(1) == 1)
                {
                    return kvinnenavnsoversikt;
                }
                else
                {
                    return herrenavnsoversikt;
                }
            }
        }

        private static StreamReader HentReader(string etternavncsv)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var navneReader = new StreamReader(assembly.GetManifestResourceStream(etternavncsv));
            return navneReader;
        }

        public Navn GenererNyttNavn()
        {
            return NyttNavnMedFornavn(Navneoversikt.HentEitNyttTilfeldigNavn(random));
        }

        public Navn GenererNyttKvinnenavn()
        {
            return NyttNavnMedFornavn(kvinnenavnsoversikt.HentEitNyttTilfeldigNavn(random));
        }

        public Navn GenererNyttHerrenavn()
        {
            return NyttNavnMedFornavn(herrenavnsoversikt.HentEitNyttTilfeldigNavn(random));
        }

        private Navn NyttNavnMedFornavn(string fornavn)
        {
            return new Navn(fornavn, etternavnsoversikt.HentEitNyttTilfeldigNavn(random));
        }
    }
}
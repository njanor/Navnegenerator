using System;
using Navnegenerator.Typar.Exceptions;
using NUnit.Framework;
using Shouldly;

namespace Navnegenerator.Typar.Testar
{
    public class NavneoversiktTestar
    {
        [Test]
        public void GenereringAvNavn_HentEitNyttTilfeldigNavn_ReturnererEitNavn()
        {
            var navnelista = new[] {"Hansen", "Jensen", "Adolfsen"};
            var navneoversikt = LagNavneoversiktMedNavn(navnelista, new[] {3, 2, 1});
            var navn = navneoversikt.HentEitNyttTilfeldigNavn();
            navnelista.ShouldContain(navn);
        }

        [Test]
        public void GenereringAvNavn_NyttTilfeldigNavnUtanNavnINavneoversikt_KastarException()
        {
            var navneoversikt = new Navneoversikt();
            Should.Throw<NavnegeneratorException>(() => navneoversikt.HentEitNyttTilfeldigNavn());
        }

        private Navneoversikt LagNavneoversiktMedNavn(string[] navn, int[] antal)
        {
            if (navn.Length != antal.Length)
                throw new Exception();
            var navneoversikt = new Navneoversikt();

            for (var i = 0; i < navn.Length; i++)
            {
                navneoversikt.LeggTilNavn(navn[i], antal[i]);
            }

            return navneoversikt;
        }
    }
}

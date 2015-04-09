using System;
using Navnegenerator.Typar.Exceptions;
using NUnit.Framework;
using Shouldly;

namespace Navnegenerator.Typar.Testar
{
    public class NavneoversiktTestar
    {
        [Test]
        public void LeggaTilNavnINavneoversikta_DersomNavnetForkjem0Gongar_SkalDetIkkjeVertaLagtTil()
        {
            var navneoversikt = LagNavneoversiktMedNavn(new[] {"Test"}, new[] {0});

            navneoversikt.HentAlleNavn().ShouldBeEmpty();
        }
        
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

        [Test]
        public void GenereringAvNavn_MangeNyeTilfeldigeNavn_GenerererProsentvisRettNavnIHenholdTilPopulariteten()
        {
            const string mestPopulæreNavn = "Andre";
            const string passePopulæreNavn = "Aron";
            const string minstPopulæreNavn = "Adrian";
            const int prosentAvMestPopulæreNavn = 50;
            const int prosentAvPassePopulæreNavn = 25;
            const int prosentAvMinstPopulæreNavn = 25;
            var navneoversikt = LagNavneoversiktMedNavn(new[] {mestPopulæreNavn, passePopulæreNavn, minstPopulæreNavn}, new[] {prosentAvMestPopulæreNavn, prosentAvPassePopulæreNavn, prosentAvMinstPopulæreNavn});

            var antalMestPopulæreNavnGenerert = 0;
            var antalPassePopulæreNavnGenerert = 0;
            var antalMinstPopulæreNavnGenerert = 0;

            const int antalNavnÅGenerera = 100000;
            const int feiltoleranse = 1000;
            const int forventaAntalMestPopulæreNavn = prosentAvMestPopulæreNavn*antalNavnÅGenerera/100;
            const int forventaAntalPassePopulæreNavn = prosentAvPassePopulæreNavn*antalNavnÅGenerera/100;
            const int forventaAntalMinstPopulæreNavn = prosentAvMinstPopulæreNavn*antalNavnÅGenerera/100;

            for (var i = 0; i < antalNavnÅGenerera; i++)
            {
                var navn = navneoversikt.HentEitNyttTilfeldigNavn();
                if (navn.Equals(mestPopulæreNavn))
                    antalMestPopulæreNavnGenerert++;
                else if (navn.Equals(passePopulæreNavn))
                    antalPassePopulæreNavnGenerert++;
                else if (navn.Equals(minstPopulæreNavn))
                    antalMinstPopulæreNavnGenerert++;
            }

            antalNavnÅGenerera.ShouldBe(antalMestPopulæreNavnGenerert + antalPassePopulæreNavnGenerert + antalMinstPopulæreNavnGenerert);

            antalMestPopulæreNavnGenerert.ShouldBeLessThan(forventaAntalMestPopulæreNavn + feiltoleranse);
            antalMestPopulæreNavnGenerert.ShouldBeGreaterThan(forventaAntalMestPopulæreNavn - feiltoleranse);
            antalPassePopulæreNavnGenerert.ShouldBeLessThan(forventaAntalPassePopulæreNavn + feiltoleranse);
            antalPassePopulæreNavnGenerert.ShouldBeGreaterThan(forventaAntalPassePopulæreNavn - feiltoleranse);
            antalMinstPopulæreNavnGenerert.ShouldBeLessThan(forventaAntalMinstPopulæreNavn + feiltoleranse);
            antalMinstPopulæreNavnGenerert.ShouldBeGreaterThan(forventaAntalMinstPopulæreNavn - feiltoleranse);
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

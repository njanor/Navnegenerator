using NUnit.Framework;
using Shouldly;

namespace Navnegenerator.Typar.Testar
{
    public class NavnTestar
    {
        [Test]
        public void ToString_NårNavnVertLagaTilString_VertDetFornuftig()
        {
            const string fornavn = "Adrian";
            const string etternavn = "Gustaviusen";
            
            var navn = new Navn(fornavn, etternavn);

            navn.ToString().ShouldBe(fornavn + ' ' + etternavn);
        }

        [Test]
        public void SamanlikningAvNavn_ToNavnMedSameFornavnOgEtternavn_SkalVeraLike()
        {
            const string fornavn = "Gustav";
            const string etternavn = "Adriansen";

            new Navn(fornavn, etternavn).ShouldBe(new Navn(fornavn, etternavn));
        }
    }
}
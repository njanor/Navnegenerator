using NUnit.Framework;
using Shouldly;

namespace NorskeNavn.Testar
{
    public class NavnegeneratorTestar
    {
        [Test]
        public void GenereringAvNavnFråSSB_GenererNyttNavn_FårSkikkelegEtternavn()
        {
            var navnegenerator = new Navnegenerator();
            var navn = navnegenerator.GenererNyttNavn();
            navn.Etternavn.ShouldNotBeEmpty();
            //TODO: Generer fornavn og slikt
            //navn.Fornavn.ShouldNotBeEmpty();
        }
    }
}
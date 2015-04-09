using System.Collections.Generic;
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
            navn.Fornavn.ShouldNotBeEmpty();
        }

        [Test]
        public void GenereringAvNavn_VedGenereringAvMangeKvinnenavn_SkalDeiIkkjeMatchaEitHerrenavn()
        {
            var navnegenerator = new Navnegenerator();
            IList<string> mangeKvinnenavn = new List<string>();
            for (int i = 0; i < 1000; i++)
            {
                mangeKvinnenavn.Add(navnegenerator.GenererNyttKvinnenavn().Fornavn);
            }
            var eitHerrenavn = navnegenerator.GenererNyttHerrenavn().Fornavn;

            mangeKvinnenavn.ShouldNotContain(eitHerrenavn);
        }
    }
}
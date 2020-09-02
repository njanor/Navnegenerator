using System;
using System.Collections.Generic;
using NUnit.Framework;
using Shouldly;

namespace NorskeNavn.Testar
{
    public class GeneratorTestar
    {
        [Test]
        public void GenereringAvNavnMedSeed_Generer_SkalGenereraSameNamn()
        {
            var seed = new Random().Next();
            var fyrsteGenerator = new Generator(seed);
            var andreGenerator = new Generator(seed);

            var fyrsteNavn = fyrsteGenerator.GenererNyttNavn();
            var andreNavn = andreGenerator.GenererNyttNavn();

            fyrsteNavn.ShouldBe(andreNavn);
        }
        
        [Test]
        public void GenereringAvNavnFråSSB_GenererNyttNavn_FårSkikkelegEtternavn()
        {
            var navnegenerator = new Generator();
            var navn = navnegenerator.GenererNyttNavn();
            navn.Etternavn.ShouldNotBeEmpty();
            navn.Fornavn.ShouldNotBeEmpty();
        }

        [Test]
        public void GenereringAvNavn_VedGenereringAvMangeKvinnenavn_SkalDeiIkkjeMatchaEitHerrenavn()
        {
            var navnegenerator = new Generator();
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
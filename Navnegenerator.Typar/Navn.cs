using System;

namespace Navnegenerator.Typar
{
    public class Navn : IEquatable<Navn>
    {
        private readonly string fornavn;
        private readonly string etternavn;

        public Navn(string fornavn, string etternavn)
        {
            this.fornavn = fornavn;
            this.etternavn = etternavn;
        }

        public string Fornavn { get { return fornavn; } }
        public string Etternavn { get { return etternavn; } }

        public bool Equals(Navn other)
        {
            return fornavn.Equals(other.fornavn) && etternavn.Equals(other.etternavn);
        }

        public override string ToString()
        {
            return fornavn + ' ' + etternavn;
        }
    }
}
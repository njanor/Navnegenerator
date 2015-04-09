using System;

namespace Navnegenerator.Typar.Exceptions
{
    public class NavnegeneratorException : Exception
    {
        public NavnegeneratorException(string feilmelding) : base(feilmelding)
        {
            
        }
    }
}
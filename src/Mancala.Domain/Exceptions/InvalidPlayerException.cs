using System;
using System.Collections.Generic;
using System.Text;

namespace Mancala.Domain.Exceptions
{
    public class InvalidPlayerException : Exception
    {
        public InvalidPlayerException() : base($"Only active player allow to play")
        {
        }
    }
}

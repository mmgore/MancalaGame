using System;
using System.Collections.Generic;
using System.Text;

namespace Mancala.Domain.Exceptions
{
    public class InvalidHouseSelectedException : Exception
    {
        public InvalidHouseSelectedException(): base($"You should choose a house to play which has seeds in it")
        {
        }
    }
}

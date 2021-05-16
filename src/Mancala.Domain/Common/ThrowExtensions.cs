using System;
using System.Collections.Generic;
using System.Text;

namespace Mancala.Domain.Common
{
    public static class ThrowExtensions
    {
        public static T ThrowIf<T>(this T @this, Func<T, bool> assert, Exception exception)
        {
            var sut = assert(@this);

            if (sut)
                throw exception;

            return @this;
        }
    }
}

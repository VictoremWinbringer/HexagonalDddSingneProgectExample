using System;

namespace ItemsService.Lib.Domain.Exceptions
{
    public class MoneyLessThanZeroException : Exception
    {
        public decimal Cash { get; }

        public MoneyLessThanZeroException(decimal cash)
        {
            Cash = cash;
        }
    }
}
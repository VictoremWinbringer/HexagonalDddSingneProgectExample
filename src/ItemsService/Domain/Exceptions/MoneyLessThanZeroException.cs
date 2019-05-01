using System;

namespace ItemsService.Domain
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
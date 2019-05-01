using ItemsService.Lib.Domain.Exceptions;

namespace ItemsService.Lib.Domain.ValueObjects
{
    public struct Money
    {
        private readonly decimal _value;

        public Money(decimal value)
        {
            if (value < 0)
                throw new MoneyLessThanZeroException(value);
            _value = value;
        }

        public decimal Value => _value;
    }
}
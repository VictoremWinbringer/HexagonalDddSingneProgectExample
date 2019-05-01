using System;

namespace ItemsService.Lib.Domain.Exceptions
{
    public class NameToLongException:Exception
    {
        public int MaxLength { get; }
        public int CurrentLength { get; }

        public NameToLongException(int maxLength, int currentLength)
        {
            MaxLength = maxLength;
            CurrentLength = currentLength;
        }
    }
}
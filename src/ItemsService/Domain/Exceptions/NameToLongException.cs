using System;

namespace ItemsService.Domain
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
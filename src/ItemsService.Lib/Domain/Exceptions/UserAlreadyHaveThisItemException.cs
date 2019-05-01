using System;

namespace ItemsService.Lib.Domain.Exceptions
{
    public class UserAlreadyHaveThisItemException : Exception
    {
        public Item Item { get; }

        public UserAlreadyHaveThisItemException(Item item)
        {
            Item = item;
        }
    }
}
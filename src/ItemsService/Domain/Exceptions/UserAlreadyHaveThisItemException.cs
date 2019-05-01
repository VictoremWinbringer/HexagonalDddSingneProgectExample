using System;

namespace ItemsService.Domain
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
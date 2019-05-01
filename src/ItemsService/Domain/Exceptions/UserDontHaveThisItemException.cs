using System;

namespace ItemsService.Domain
{
    public class UserDontHaveThisItemException : Exception
    {
        public Item Item { get; }

        public UserDontHaveThisItemException(Item item)
        {
            Item = item;
        }
    }
}
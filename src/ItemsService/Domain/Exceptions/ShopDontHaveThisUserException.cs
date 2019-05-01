using System;

namespace ItemsService.Domain
{
    public class ShopDontHaveThisUserException : Exception
    {
        public Id User { get; }

        public ShopDontHaveThisUserException(Id user)
        {
            User = user;
        }
    }
}
using System;
using ItemsService.Lib.Domain.ValueObjects;

namespace ItemsService.Lib.Domain.Exceptions
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
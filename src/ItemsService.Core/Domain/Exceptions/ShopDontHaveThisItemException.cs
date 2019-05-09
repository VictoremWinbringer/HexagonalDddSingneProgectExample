using System;
using ItemsService.Lib.Domain.ValueObjects;

namespace ItemsService.Lib.Domain.Exceptions
{
    public class ShopDontHaveThisItemException : Exception
    {
        public Id Item { get; }

        public ShopDontHaveThisItemException(Id item)
        {
            Item = item;
        }
    }
}
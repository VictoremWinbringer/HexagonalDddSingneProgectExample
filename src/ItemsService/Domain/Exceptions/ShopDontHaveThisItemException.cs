using System;

namespace ItemsService.Domain
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
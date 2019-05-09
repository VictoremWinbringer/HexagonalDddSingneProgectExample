using System.Collections.Generic;
using ItemsService.Lib.Domain;

namespace ItemsService.Lib.UseCase
{
    public interface IItemsService
    {
        List<Item> GetAll();
        void Add(Item entity);
        void Buy(string userId, string itemId, string shopId);
    }
}
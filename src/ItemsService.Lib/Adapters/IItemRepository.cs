using System.Collections.Generic;
using ItemsService.Lib.Domain;

namespace ItemsService.Lib.Adapters
{
    public interface IItemRepository
    {
        List<Item> GetAll();
        void Save(Item entity);
    }
}
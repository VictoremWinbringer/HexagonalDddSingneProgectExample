using System.Collections.Generic;

namespace ItemsService.Domain
{
    public interface IItemRepository
    {
        List<Item> GetAll();
        void Save(Item entity);
    }
}
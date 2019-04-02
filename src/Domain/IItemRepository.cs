using System.Collections.Generic;

namespace ItemsService.Domain
{
    public interface IItemRepository
    {
        List<ItemEntity> GetAll();
        void Save(ItemEntity entity);
    }
}
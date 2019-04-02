using System.Collections.Generic;

namespace ItemsLib.Domain
{
    public interface IItemRepository
    {
        List<ItemEntity> GetAll();
        void Save(ItemEntity entity);
    }
}
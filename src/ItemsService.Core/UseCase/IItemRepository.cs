using System.Collections.Generic;
using ItemsService.Lib.Domain;

namespace ItemsService.Lib.UseCase
{
    public interface IItemRepository
    {
        List<Item> GetAll();
        void Save(Item entity);
    }
}
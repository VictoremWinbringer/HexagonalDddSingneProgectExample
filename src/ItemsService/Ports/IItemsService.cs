using System.Collections.Generic;
using ItemsService.Domain;

namespace ItemsService.Services
{
    public interface IItemsService
    {
        List<Item> GetAll();
        void Add(Item entity);
    }
}
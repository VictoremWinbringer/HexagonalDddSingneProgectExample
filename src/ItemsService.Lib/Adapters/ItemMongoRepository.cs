using System.Collections.Generic;
using System.Linq;
using ItemsService.Lib.Domain;
using MongoDB.Driver;

namespace ItemsService.Lib.Adapters
{
    public class ItemMongoRepository : IItemRepository
    {
        private readonly IMongoCollection<ItemDto> _items;

        public ItemMongoRepository(IMongoDatabase database)
        {
            _items = database.GetCollection<ItemDto>("Items");
        }

        public List<Item> GetAll()
        {
            return _items
                .Find(item => true)
                .ToList()
                .Select(item => item.ToItem())
                .ToList();
        }

        public void Save(Item entity)
        {
            var item = new ItemDto(entity);
            _items.InsertOne(item);
        }
    }
}
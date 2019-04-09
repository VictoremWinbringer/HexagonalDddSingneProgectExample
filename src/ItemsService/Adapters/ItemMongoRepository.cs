using System.Collections.Generic;
using System.Linq;
using ItemsService.Domain;
using MongoDB.Driver;

namespace ItemsService.Adapters
{
    public class ItemMongoRepository : IItemRepository
    {
        private readonly IMongoCollection<Item> _items;

        public ItemMongoRepository(IMongoDatabase database)
        {
            _items = database.GetCollection<Item>("Items");
        }

        public List<ItemEntity> GetAll()
        {
            return _items
                .Find(item => true)
                .ToList()
                .Select(item => item.ToEntity())
                .ToList();
        }

        public void Save(ItemEntity entity)
        {
            var item = new Item(entity);
            _items.InsertOne(item);
        }
    }
}
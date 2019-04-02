using System.Collections.Generic;
using ItemsService.Domain;
using MongoDB.Driver;
using System.Linq;

namespace ItemsService.Adapters
{
    public class ItemMongoRepository : IItemRepository
    {
        private readonly IMongoCollection<ItemDto> _items;

        public ItemMongoRepository(IMongoDatabase database)
        {
            _items = database.GetCollection<ItemDto>("Items");
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
            var item = new ItemDto(entity);
            _items.InsertOne(item);
        }
    }
}
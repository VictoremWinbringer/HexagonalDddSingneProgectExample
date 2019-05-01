using System.Collections.Generic;
using System.Linq;
using ItemsService.Domain;
using MongoDB.Driver;

namespace ItemsService.Adapters
{
    public class ItemMongoRepository : IItemRepository
    {
        private readonly IMongoCollection<ItemDto> _items;

        public ItemMongoRepository(IMongoDatabase database)
        {
            _items = database.GetCollection<ItemDto>("Items");
        }

        public List<Domain.Item> GetAll()
        {
            return _items
                .Find(item => true)
                .ToList()
                .Select(item => item.ToEntity())
                .ToList();
        }

        public void Save(Domain.Item entity)
        {
            var item = new ItemDto(entity);
            _items.InsertOne(item);
        }
    }
}
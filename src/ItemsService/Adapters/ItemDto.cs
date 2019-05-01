using ItemsService.Domain;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ItemsService.Adapters
{
    public class ItemDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }
        
        public decimal Price { get; set; }

        public ItemDto(Item entity)
        {
            Name = entity.Name.Value;
            Price = entity.Price.Value;
            Id = entity.Id.Value;
        }

        // Use AutoMapper for this in big project.
        public Item ToItem()
        {
            return new Item(Id,Name, Price);
        }
    }
}
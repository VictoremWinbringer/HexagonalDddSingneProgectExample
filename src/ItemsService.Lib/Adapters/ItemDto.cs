using ItemsService.Lib.Domain;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ItemsService.Lib.Adapters
{
    public class ItemDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Text { get; set; }
        
        public decimal Price { get; set; }

        public ItemDto(Item entity)
        {
            Text = entity.Name.Value;
            Price = entity.Price.Value;
            Id = entity.Id.Value;
        }

        // Use AutoMapper for this in big project.
        public Item ToItem()
        {
            return new Item(Id,Text, Price);
        }
    }
}
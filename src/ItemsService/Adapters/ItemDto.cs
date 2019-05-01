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

        public ItemDto(Domain.Item entity)
        {
            this.Name = entity.Name.Value;
            this.Price = entity.Price.Value;
        }

        // Use AutoMapper for this in big project.
        public Domain.Item ToEntity()
        {
            return new Domain.Item(new Name(this.Name), new Money(this.Price));
        }
    }
}
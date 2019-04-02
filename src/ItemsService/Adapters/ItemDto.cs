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
        
        
        public string Text { get; set; }

        public ItemDto(ItemEntity entity)
        {
            this.Text = entity.Text;
        }

        // Use AutoMapper for this in big project.
        public ItemEntity ToEntity()
        {
            return new ItemEntity
            {
                Text = this.Text
            };
        }
    }
}
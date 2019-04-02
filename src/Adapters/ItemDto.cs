using ItemsService.Domain;

namespace ItemsService.Adapters
{
    public class ItemDto
    {
        public string Text { get; set; }

        public ItemDto(ItemEntity entity)
        {
        }
    }
}
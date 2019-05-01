using ItemsService.Domain;

namespace ItemsService.Controllers
{
    public class ItemCreateModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Item ToItem()
        {
            return new Item(Name,Price);
        }
    }
}
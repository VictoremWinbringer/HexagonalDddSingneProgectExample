

using ItemsService.Lib.Domain;

namespace ItemsService.UI.MvcRpc.Models
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
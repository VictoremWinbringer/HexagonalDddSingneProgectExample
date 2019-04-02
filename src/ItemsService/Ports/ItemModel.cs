using System.ComponentModel.DataAnnotations;
using ItemsLib.Domain;

namespace ItemsService.Controllers
{
    public class ItemModel
    {
        [MaxLength(255)] public string Text { get; set; }

        public ItemModel(ItemEntity entity)
        {
            this.Text = entity.Text;
        }

        public ItemModel()
        {
            
        }

        public ItemEntity ToEntity()
        {
            return new ItemEntity()
            {
                Text = this.Text
            };
        }
    }
}
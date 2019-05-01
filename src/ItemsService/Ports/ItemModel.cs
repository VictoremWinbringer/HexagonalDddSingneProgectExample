using System;
using System.ComponentModel.DataAnnotations;
using ItemsService.Domain;

namespace ItemsService.Controllers
{
    public class ItemModel
    {
        public string Id { get; set; }
        
        [Display(Name = "Название")]
        public string Name { get; set; }
        
        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        public ItemModel(Item entity)
        {
            this.Name = entity.Name.Value;
        }

        [Obsolete("For json serialization only")]
        public ItemModel()
        {
            
        }

        public Item ToEntity()
        {
            return new Item(new Id(this.Id),  new Name(this.Name), new Money(0));
        }
    }
}
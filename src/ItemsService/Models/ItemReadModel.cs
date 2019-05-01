using System;
using System.ComponentModel.DataAnnotations;
using ItemsService.Domain;

namespace ItemsService.Controllers
{
    public class ItemReadModel
    {
        public string Id { get; set; }
        
        [Display(Name = "Название")]
        public string Name { get; set; }
        
        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        public ItemReadModel(Item entity)
        {
            this.Name = entity.Name.Value;
        }
    }
}
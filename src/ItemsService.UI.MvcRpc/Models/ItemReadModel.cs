using System;
using System.ComponentModel.DataAnnotations;
using ItemsService.Lib.Domain;

namespace ItemsService.UI.MvcRpc.Models
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
            Name = entity.Name.Value;
            Price = entity.Price.Value;
            Id = entity.Id.Value;
        }
        
        [Obsolete("For serialization")]
        public ItemReadModel()
        {
            
        }
    }
}
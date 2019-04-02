using System.Collections.Generic;
using System.Linq;
using ItemsService.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ItemsService.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IItemsService _service;

        public ItemsController(IItemsService service)
        {
            _service = service;
        }
        
        [HttpPost]
        public List<ItemModel> GetAll()
        {
            return _service.GetAll().Select(item => new ItemModel(item)).ToList();
        }

        [HttpPost]
        public void Post(ItemModel model)
        {
            _service.Add(model.ToEntity());
        }
    }
}
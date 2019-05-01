using System.Collections.Generic;
using System.Linq;
using ItemsService.Models;
using Microsoft.AspNetCore.Mvc;

namespace ItemsService.Controllers
{
    public class ItemsController : Controller
    {
        private readonly Lib.Ports.IItemsService _service;

        public ItemsController(Lib.Ports.IItemsService service)
        {
            _service = service;
        }


        public List<ItemReadModel> GetAll()
        {
            return _service.GetAll().Select(item => new ItemReadModel(item)).ToList();
        }

        [HttpPost]
        public void Add([FromBody] ItemCreateModel model)
        {
            _service.Add(model.ToItem());
        }

        [HttpPost]
        public void Buy(string userId, string itemId, string shopId)
        {
            _service.Buy(userId, itemId, shopId);
        }
    }
}
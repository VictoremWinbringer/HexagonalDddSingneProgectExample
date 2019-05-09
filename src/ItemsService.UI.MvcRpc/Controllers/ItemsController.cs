using System.Collections.Generic;
using System.Linq;
using ItemsService.Lib.UseCase;
using ItemsService.UI.MvcRpc.Models;
using Microsoft.AspNetCore.Mvc;

namespace ItemsService.UI.MvcRpc.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IItemsService _service;

        public ItemsController(IItemsService service)
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
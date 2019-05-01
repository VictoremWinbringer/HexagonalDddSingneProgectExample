using System.Collections.Generic;
using System.Linq;
using ItemsService.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ItemsService.Controllers
{
    public class ItemsController : Controller
    {
        private readonly Services.ItemsService _service;

        public ItemsController(Services.ItemsService service)
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
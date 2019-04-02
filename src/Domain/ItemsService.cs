using System.Collections.Generic;

namespace ItemsService.Domain
{
    public interface IItemsService
    {
        List<ItemEntity> GetAll();
        void Add(ItemEntity entity);
    }

    public class ItemsService : IItemsService
    {
        private readonly IItemRepository _repository;

        public ItemsService(IItemRepository repository)
        {
            _repository = repository;
        }

        public List<ItemEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public void Add(ItemEntity entity)
        {
            _repository.Save(entity);
        }
    }
}
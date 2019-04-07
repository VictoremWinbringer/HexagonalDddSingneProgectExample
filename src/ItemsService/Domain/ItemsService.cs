using System;
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
            if(string.IsNullOrWhiteSpace(entity?.Text) || entity.Text.Length < 4 || entity.Text.Length > 255)
                throw new ArgumentException("Text");
            _repository.Save(entity);
        }
    }
}
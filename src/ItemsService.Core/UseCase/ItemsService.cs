using System.Collections.Generic;
using ItemsService.Lib.Domain;
using ItemsService.Lib.Domain.ValueObjects;

namespace ItemsService.Lib.UseCase
{
    public class ItemsService : IItemsService
    {
        private readonly IItemRepository _repository;

        public ItemsService(IItemRepository repository)
        {
            _repository = repository;
        }

        public List<Item> GetAll()
        {
            return _repository.GetAll();
        }

        public void Add(Item item)
        {
            /*
             В нормальном приложении тут должен быть поставшик
             Нужно создать объектно представления докумена о выгрузке новых предметов 
             в мазагин и т.д. и т. п. В общем ООП во все поля с гигантским количеством объектов
             да и вообще добавлять не просто в БД а в магазин т. е.
             
             shop.Add(item)
             _shopRepository.Save(shop);
             
             */
            
            _repository.Save(item);
        }

        public void Buy(string userId, string itemId, string shopId)
        { 
            /*
             Тут мне лень писать реальную логику для учебного примера поэтому будет так. Хотя таки да, ради Хабра
             можно было бы и постаратся но не сегодня
             Тут на самом деле надо создать объект покупки (вроде Order)  и т. д.
             и т. п.  Еще и в транзакцию это все завернуть. В оббщем опять куча разных 
             объектов и ООП во все поля. Мне лень для учебного проекта это делать
             */
            
            Shop shop = null; //Надо бы его из _shopsRepository.Get( new Id(shopId)); но мне лень репоизиторий писать
            shop.Sell( new Id(itemId), new Id(userId));
            // _shopRepository.Save(shop)
         }
    }
}
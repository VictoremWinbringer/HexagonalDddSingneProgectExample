using System.Collections.Generic;
using ItemsService.Lib.Domain.Exceptions;
using ItemsService.Lib.Domain.ValueObjects;

namespace ItemsService.Lib.Domain
{
    public class Shop
    {
        public Id Id { get; set; }
        
        private readonly List<Item> _items = new List<Item>();
        private readonly List<User> _users = new List<User>();
        
        public IReadOnlyCollection<Item> Items => _items.AsReadOnly();
        public IReadOnlyCollection<User> Users => _users.AsReadOnly();
        
        public Money Money { get; protected set; }
        
        public void Sell(Id itemId,Id userId)
        {
            var item = _items.Find(i => i.Id.Value == itemId.Value);
            var user = _users.Find(u => u.Id.Value == userId.Value);
            
            if (item == null)
                throw new ShopDontHaveThisItemException(itemId);
            
            if(user == null)
                throw  new ShopDontHaveThisUserException(userId);
            
            user.Buy(item);
            Money = new Money(Money.Value + item.Price.Value);
            _items.RemoveAll(i => i.Id.Value == item.Id.Value);
           
        }
    }
}
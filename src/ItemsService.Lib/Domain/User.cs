using System.Collections.Generic;
using System.Linq;
using ItemsService.Lib.Domain.Exceptions;
using ItemsService.Lib.Domain.ValueObjects;

namespace ItemsService.Lib.Domain
{
    // Для простоты примера у нас тут пользователь только с наличкой
    // По нормальному нужно еще сушьность кошелек пользователя вводить и т.д.
    public class User
    {
        public Id Id { get; set; }

        private readonly List<Item> _items = new List<Item>();

        public IReadOnlyCollection<Item> Items => _items.AsReadOnly();

        public Name Name { get; }

        public Money Money { get; protected set; }

        public void Buy(Item item)
        {
            if (_items.Any(i => i.Id.Value == item.Id.Value))
                throw new UserAlreadyHaveThisItemException(item);
            Money = new Money(Money.Value - item.Price.Value);
            _items.Add(item);
        }

      
    }
}
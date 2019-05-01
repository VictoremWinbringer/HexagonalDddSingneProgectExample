namespace ItemsService.Domain
{
    public class Item
    {
        public Id Id { get; }
        public Name Name { get; }
        public Money Price { get; }

        public Item(string id, string name, decimal price)
        {
            Id = new Id(id);
            Name = new Name(name);
            Price = new Money(price);
        }

        public Item(string name, decimal price)
        {
            Id = new Id();
            Name = new Name(name);
            Price = new Money(price);
        }
    }
}
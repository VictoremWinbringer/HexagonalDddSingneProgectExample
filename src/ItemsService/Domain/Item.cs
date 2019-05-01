namespace ItemsService.Domain
{
    public class Item
    {
        public Id Id { get; set; }
        public Name Name { get;}
        public Money Price { get;}
        
        public Item(Id id,Name name, Money price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
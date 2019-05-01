namespace ItemsService.Domain
{
    public struct Id
    {
        private readonly string _value;

        public string Value => _value;

        public Id(string id)
        {
            if(string.IsNullOrWhiteSpace(id))
                throw new IdIsEmptyException();
            _value = id;
        }
    }
}
using System.Text.RegularExpressions;

namespace ItemsService.Domain
{
    public struct Name
    {
        private readonly string _name;
        
        public Name(string name)
        {
            var maxLength = 100;
            var nameFormat = "[a-zA-Z0-9_ ]";
            
            if(string.IsNullOrWhiteSpace(name))
                throw new NameIsEmptyException();
            
            if(name.Length>100)
                throw new NameToLongException(maxLength,name.Length);
            
            if(!Regex.IsMatch(name,nameFormat))
                throw new NameFormatException(name,nameFormat);
                
            _name = name;
        }

        public string Value => _name;
    }
}
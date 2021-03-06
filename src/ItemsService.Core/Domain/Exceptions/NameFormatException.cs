using System;

namespace ItemsService.Lib.Domain.Exceptions
{
    public class NameFormatException:Exception
    {
        public string Name { get; }
        public string ExpectedFormat { get; }

        public NameFormatException(string name, string expectedFormat)
        {
            Name = name;
            ExpectedFormat = expectedFormat;
        }
    }
}
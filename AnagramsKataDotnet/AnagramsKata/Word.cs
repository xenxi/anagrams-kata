using System.Collections.Generic;
using System.Linq;

namespace AnagramsKata
{
    public class Word
    {
        public Word(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public IEnumerable<string> GetConvinations(string aGivenEmptyInputString)
        {
            return Enumerable.Empty<string>();
        }
    }
}
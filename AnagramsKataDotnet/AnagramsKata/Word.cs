using System;
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

        public IEnumerable<string> GetConvinations()
        {
            if (string.IsNullOrWhiteSpace(Value))
                return Enumerable.Empty<string>();

            return Enumerable.Range(0, 120).Select(x => string.Empty);
        }
    }
}
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

            return GetCombinations(Value).Where(x => x.Length == Value.Length);
        }

        private static IEnumerable<string> GetCombinations(IEnumerable<char> items)
        {
            var combinations = new List<string> { string.Empty };

            foreach (var item in items)
            {
                var newCombinations = new List<string>();

                foreach (var combination in combinations)
                {
                    for (var i = 0; i <= combination.Length; i++)
                    {
                        newCombinations.Add(
                            combination.Substring(0, i) +
                            item +
                            combination.Substring(i));
                    }
                }

                combinations.AddRange(newCombinations);
            }

            return combinations;
        }
    }
}
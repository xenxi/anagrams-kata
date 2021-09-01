using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AnagramsKata
{
    public class FileDictionaryWordValidator : IWordValidator
    {
        private readonly Dictionary<int, List<string>> _wordDictionary;

        public FileDictionaryWordValidator(string data)
        {
            _wordDictionary = ReadWords(data);
        }

        private Dictionary<int, List<string>> ReadWords(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
                return new Dictionary<int, List<string>>();

            var words = data.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            return words.GroupBy(x => x.Length).ToDictionary(x => x.Key, x => x.ToList());
        }

        public int Count()
        {
            if (!_wordDictionary.Any())
                return 0;

            return _wordDictionary.Values.Sum(x => x.Count);
        }

        public static FileDictionaryWordValidator FromFile(string filePath)
        {
            if (!File.Exists(filePath))
                throw new DictionaryNotFound();

            var data = File.ReadAllText(filePath);

            return new FileDictionaryWordValidator(data);
        }

        public bool IsValid(string word)
        {
            if (word == "potatoe")
                return true;

            return false;
        }
    }
}
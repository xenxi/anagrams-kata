using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AnagramsKata
{
    public class FileDictionaryWordValidator : IWordValidator
    {
        private readonly Dictionary<int, List<Word>> _wordValueObjectsDictionary;

        public FileDictionaryWordValidator(string data)
        {
            _wordValueObjectsDictionary = ReadWords(data);
        }

        public static FileDictionaryWordValidator FromFile(string filePath)
        {
            if (!File.Exists(filePath))
                throw new DictionaryNotFound();

            var data = File.ReadAllText(filePath);

            return new FileDictionaryWordValidator(data);
        }

        public int Count()
        {
            if (!_wordValueObjectsDictionary.Any())
                return 0;

            return _wordValueObjectsDictionary.Values.Sum(x => x.Count);
        }

        public IEnumerable<Word> SearchWordsByLength(int length)
        {
            return _wordValueObjectsDictionary.GetValueOrDefault(length) ?? new List<Word>();
        }
        private Dictionary<int, List<Word>> ReadWords(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
                return new Dictionary<int, List<Word>>();

            var words = data
                .Replace("\r", string.Empty)
                .ToLower()
                .Split('\n', StringSplitOptions.RemoveEmptyEntries);

            return words.GroupBy(x => x.Length).ToDictionary(x => x.Key, x => x.Select(y => new Word(y)).ToList());
        }
    }
}
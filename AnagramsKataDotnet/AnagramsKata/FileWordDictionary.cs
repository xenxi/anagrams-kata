using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AnagramsKata
{
    public class FileWordDictionary : IWordDictionary
    {
        private readonly Dictionary<int, List<Word>> _wordValueObjectsDictionary;

        public FileWordDictionary(string data)
        {
            _wordValueObjectsDictionary = ReadWords(data);
        }

        public static FileWordDictionary FromFile(string filePath)
        {
            if (!File.Exists(filePath))
                throw new DictionaryNotFound();

            var data = File.ReadAllText(filePath);

            return new FileWordDictionary(data);
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
                .Split('\n', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => new Word(x));

            return words.GroupBy(x => x.Length).ToDictionary(x => x.Key, x => x.ToList());
        }

        Words IWordDictionary.SearchWordsByLength(int length)
        {
            var words = _wordValueObjectsDictionary.GetValueOrDefault(length) ?? new List<Word>();

            return new Words(words);
        }
    }
}
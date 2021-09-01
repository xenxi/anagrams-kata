using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AnagramsKata
{
    public class FileDictionaryWordValidator : IWordValidator
    {
        private readonly Dictionary<int, List<string>> _wordDictionary;
        private (string OrderWord, List<string> Words) _lastSearch;

        public FileDictionaryWordValidator(string data)
        {
            _wordDictionary = ReadWords(data);
            _lastSearch = (string.Empty, new List<string>());
        }

        private Dictionary<int, List<string>> ReadWords(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
                return new Dictionary<int, List<string>>();

            var words = data.Replace("\r", string.Empty).Split('\n', StringSplitOptions.RemoveEmptyEntries);

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
            if (string.IsNullOrWhiteSpace(word))
                return false;

            var words = SearchWordsWithSameLength(word);

            return words.Any(x => x.Equals(word, StringComparison.CurrentCultureIgnoreCase));
        }

        private List<string> SearchWordsWithSameLength(string word)
        {
            var orderWord = OrderWord(word.ToLower());
            if( _lastSearch.OrderWord != orderWord)
            {
                _lastSearch = (orderWord, _wordDictionary.GetValueOrDefault(word.Length));
                _lastSearch.Words = _lastSearch.Words
                    .Where(x => OrderWord(x).Equals(orderWord, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }


            return _lastSearch.Words;
        }

        private static string OrderWord(string word)
        {
            return new string(word.ToCharArray().OrderBy(x => x).ToArray());
        }
    }
}
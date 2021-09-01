using System.Collections.Generic;
using System.Linq;

namespace AnagramsKata
{
    public class FileDictionaryWordValidator
    {
        private readonly Dictionary<int, List<string>> _wordDictionary;

        public FileDictionaryWordValidator(string data)
        {
            _wordDictionary = ReadWords(data);
        }

        private Dictionary<int, List<string>> ReadWords(string data)
        {
            var words = data.Split('\n');

            return words.GroupBy(x => x.Length).ToDictionary(x => x.Key, x => x.ToList());
        }

        public int Count()
        {
            return _wordDictionary.Values.Sum(x => x.Count);
        }
    }
}
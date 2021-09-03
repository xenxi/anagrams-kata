using System.Collections.Generic;

namespace AnagramsKata
{
    public class AnagramSearcher
    {
        private readonly IWordDictionary _dictionary;

        public AnagramSearcher(IWordDictionary dictionary)
        {
            _dictionary = dictionary;
        }

        public ICollection<string> Search(string aGivenEmptyInputString)
        {
            return GetAllAnagrams(aGivenEmptyInputString).AsString();
        }

        private Words GetAllAnagrams(Word word)
        {
            if (word.Length < 2)
                return Words.Empty();

            var wordsWithSameLegth = _dictionary.SearchWordsByLength(word.Length);

            return wordsWithSameLegth.GetAnagrams(word);
        }
    }
}
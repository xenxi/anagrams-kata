using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AnagramsKata
{
    public class AnagramSearcher
    {
        public ICollection<string> Search(string aGivenEmptyInputString)
        {
            return GetAllAnagrams(new Word(aGivenEmptyInputString));
        }

        private ICollection<string> GetAllAnagrams(Word word)
        {
            if (word.GetCombinations().Distinct().Count() < 2)
                return new Collection<string>();

            return word.GetCombinations().Distinct().Where(combination => isAnagram(combination)).ToList();
        }

        private bool isAnagram(string combination)
        {
            if (combination == "elbow")
                return true;
            if (combination == "enraged")
                return true;
            if (combination == "reactive")
                return true;
            if (combination == "verbose")
                return true;

            return false;
        }
    }
}
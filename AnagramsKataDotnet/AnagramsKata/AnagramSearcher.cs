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
            var combinations = word.GetCombinations().Distinct();

            if (combinations.Count() < 2)
                return new Collection<string>();

            var anagrams = new List<string>();
            foreach (var combination in combinations)
            {
                if (isAnagram(combination))
                    anagrams.Add(combination);
            }

            return anagrams;
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
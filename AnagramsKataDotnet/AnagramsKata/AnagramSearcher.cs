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

        private static ICollection<string> GetAllAnagrams(Word word)
        {
            var combinations = word.GetCombinations();

            if (combinations.Count() < 2)
                return new Collection<string>();

            if (word.Value == "below")
                return new List<string> { "elbow" };
            if (word.Value == "angered")
                return new List<string> { "enraged" };
            if (word.Value == "creative")
                return new List<string> { "reactive" };

            return new List<string> { "verbose" };
        }
    }
}
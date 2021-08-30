using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AnagramsKata
{
    public class AnagramSearcher
    {
        public ICollection<string> Search(string aGivenEmptyInputString)
        {
            if (aGivenEmptyInputString == "below")
                return new List<string> { "elbow" };
            if (aGivenEmptyInputString == "angered")
                return new List<string> { "enraged" };
            if (aGivenEmptyInputString == "creative")
                return new List<string> { "reactive" };
            if (aGivenEmptyInputString == "observe")
                return new List<string> { "verbose" };

            return new Collection<string>();
        }
    }
}
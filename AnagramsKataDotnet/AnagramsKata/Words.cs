using System;
using System.Collections.Generic;
using System.Linq;

namespace AnagramsKata
{
    public class Words
    {
        private readonly List<Word> words;

        public Words(List<Word> words)
        {
            this.words = words;
        }

        public ICollection<string> AsString()
        {
            return words.Select(x => x.Value).ToList();
        }

        public Words GetAnagrams(Word word)
        {
            return new Words(words.Where(word.IsAnagramOf).ToList());
        }

        public static Words Empty()
        {
            return new Words(new List<Word>());
        }
    }
}
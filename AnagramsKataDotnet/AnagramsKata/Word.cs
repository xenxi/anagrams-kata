using System.Collections.Generic;
using System.Linq;

namespace AnagramsKata
{
    public class Word
    {
        private readonly string _anagramKey;

        public Word(string value)
        {
            Value = NormalizeString(value);
            _anagramKey = OrderCharacters(Value);
        }

        public int Length => Value.Length;

        public string Value { get; }

        public bool IsAnagramOf(Word word)
        {
            return Length == word.Length && _anagramKey == word._anagramKey && Value != word.Value;
        }

        private static string NormalizeString(string value)
        {
            if (value == null)
                return string.Empty;

            return value.Replace("\r", string.Empty).ToLower();
        }

        private static string OrderCharacters(string word)
        {
            return new string(word.ToCharArray().OrderBy(x => x).ToArray());
        }

        public override bool Equals(object obj)
        {
            return obj is Word word &&
                   Value == word.Value;
        }

        public static implicit operator Word(string val) => new Word(val);

        public static bool operator ==(Word left, Word right)
        {
            return EqualityComparer<Word>.Default.Equals(left, right);
        }

        public static bool operator !=(Word left, Word right)
        {
            return !(left == right);
        }
    }
}
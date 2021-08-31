using System.Linq;

namespace AnagramsKata.Tests
{
    public class StringValueObjectTestCase
    {
        protected int VariationsWithoutRepetition(string wordStr)
        {
            var length = wordStr.Length - wordStr.GroupBy(x => x).Count(x => x.Count() == 1);
            var expectedTotalAnagrams = Factorial(wordStr.Length) / Factorial(length);
            return expectedTotalAnagrams;
        }

        private static int Factorial(int number)
        {
            var factorial = 1;
            for (var i = 1; i <= number; i++)
                factorial *= i;

            return factorial;
        }
    }
}
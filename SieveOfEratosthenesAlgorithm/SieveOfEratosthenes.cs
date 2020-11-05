using System;
using System.Collections.Generic;
using System.Text;

namespace SieveOfEratosthenesAlgorithm
{
    public static class SieveOfEratosthenes
    {
        /// <summary>
        /// Generates the sequence of prime numbers.
        /// </summary>
        /// <param name="count">Sequence length.</param>
        /// <returns>A sequence of <paramref name="count"/> first prime numbers.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="count"/> is less than 1.</exception>
        public static IEnumerable<int> GetPrimeNumbers(int count)
        {
            ValidateCurrentOfValueLessOne(count);
            List<int> primeNumbers = new List<int>();
            primeNumbers.Add(2);

            for (int i = 3; i <= count; i++)
            {
                if (i % 2 != 0)
                {
                    primeNumbers.Add(i);
                }
            }

            for (int i = 3; i * i <= count; i++)
            {
                if (primeNumbers.Contains(i))
                {
                    for (int j = i * i; j <= count; j += i)
                        primeNumbers.Remove(j);
                }
            }

            return primeNumbers;
        }

        private static void ValidateCurrentOfValueLessOne(int value)
        {
            if (value < 1)
            {
                throw new ArgumentException("Elements can't be less than one", nameof(value));
            }
        }
    }
}

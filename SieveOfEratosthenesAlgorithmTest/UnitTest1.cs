using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using NUnit.Framework;
using SieveOfEratosthenesAlgorithm;

namespace SieveOfEratosthenesAlgorithmTest
{
    [TestFixture]
    public class SequenceGeneratorTests
    {
        private static IEnumerable<TestCaseData> PrimeNumbersTestCases
        {
            get
            {
                yield return new TestCaseData(12, new[] { 2, 3, 5, 7, 11 });
                yield return new TestCaseData(30, new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 });
                yield return new TestCaseData(
                    230,
                    new[]
                    {
                        2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97,
                        101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193,
                        197, 199, 211, 223, 227, 229,
                    });
                yield return new TestCaseData(
                    542,
                    new[]
                    {
                        2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97,
                        101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193,
                        197, 199, 211, 223, 227, 229, 233, 239, 241, 251, 257, 263, 269, 271, 277, 281, 283, 293, 307,
                        311, 313, 317, 331, 337, 347, 349, 353, 359, 367, 373, 379, 383, 389, 397, 401, 409, 419, 421,
                        431, 433, 439, 443, 449, 457, 461, 463, 467, 479, 487, 491, 499, 503, 509, 521, 523, 541
                    });
            }
        }


        [TestCaseSource(nameof(PrimeNumbersTestCases))]
        public void GetPrimeNumbersTests(int count, int[] expected)
        {
            var actual = SieveOfEratosthenes.GetPrimeNumbers(count);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-90)]
        public void GetPrimeNumbers_LengthOfSequenceLessThanOne_ThrowArgumentException(int count)
            => Assert.Throws<ArgumentException>(() => SieveOfEratosthenes.GetPrimeNumbers(count),
                message: "Method throws ArgumentException in case length of the sequence is less than 1.");
    }
}
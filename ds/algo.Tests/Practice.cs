using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace algo.Tests
{
    [TestFixture]
    class Practice
    {
        [Test]
        public void SubsetWithSumDivisibleByANumber()
        {
            //var result = FindDivisibleBy(new[] {3, 1, 7, 5}, 6);
        }

        private bool FindDivisibleBy(int[] set, int value)
        {
            var start = 0;
            var end = set.Length;
            while (start < end)
            {
                if (set[start] >= value)
                {
                    if (set[start]%value == 0)
                    {
                        return true;
                    }
                }
                if (set[end] >= value)
                {
                    if (set[end] % value == 0)
                    {
                        return true;
                    }
                }
                if (set[start] + set[end] >= value )
                {
                    if ((set[start] + set[end])%value == 0)
                    {
                        return true;
                    }
                }
                start++;
                end++;
            }
            return false;
        }
    }
}

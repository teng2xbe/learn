using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace algo.Tests
{
    [TestFixture]
    public class GivenSetOfArrays_ReturnMinimumSetThatCanSatisfyAll
    {
        
        [Test]
        public void GivenSetOfArray_ReturnMinimumSetForAll1()
        {
            var array1 = new[] { 3, 7, 5, 2, 9 };
            var array2 = new[] { 5 };
            var array3 = new[] { 2, 3 };
            var array4 = new[] { 4 };
            var array5 = new[] { 3, 4, 3, 5, 7, 4 };


            var result = GetDrinksForAll(new[] {array1, array2, array3, array4, array5});
            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result[0].Contains(5) && result[0].Contains(3) && result[0].Contains(4));
            Assert.IsTrue(result[1].Contains(5) && result[1].Contains(2) && result[1].Contains(4));

        }

        private IList<IList<int>> GetDrinksForAll(int[][] customersDrinks)
        {
            var initResult = InitializeResult(customersDrinks);
            var result = new List<IList<int>>();
            if (initResult.Count == 1)
            {
                result.Add(new List<int> {initResult.First()});
            }

            var i = 2;
            while (i < initResult.Count)
            {
                var combinations = new List<int[]>();
                GetSubSets(initResult.ToArray(), i, combinations);
                foreach (var combi in combinations)
                {
                    if (IsCombinationPresentToAll(combi, customersDrinks))
                    {
                        result.Add(combi);
                    }
                }
                i++;
            }
            return result;
        }

        private bool IsCombinationPresentToAll(int[] drinks, int[][] customerDrinks)
        {
            var result = new bool[customerDrinks.Length];
            for (int i = 0; i < customerDrinks.Length; i++)
            {
                for (int j = 0; j < customerDrinks[i].Length; j++)
                {
                    if (drinks.Contains(customerDrinks[i][j]))
                    {
                        result[i] = true;
                        break;
                    }
                }
            }

            var isPresent = true;
            foreach (bool t in result)
            {
                isPresent &= t;
            }
            return isPresent;
        }

        private HashSet<int> InitializeResult(int[][] customersDrinks)
        {
            var result = new HashSet<int>();

            for (var i = 0; i < customersDrinks.Length - 1; i++)
            {
                result.Add(customersDrinks[i][0]);
            }

            return result;
        }

        private void GetSubSets(int[] source, int length, IList<int[]> result)
        {
            //source: {5,3,2,4}
            //length: 2
            //out: {5,3},{5,2},{5,4},{3,2},{3,4},{2,4}

            if (source.Length < length)
            {
                return;
            }
            
            for (var i = length - 1; i < source.Length; i++)
            {
                var subSet = InitSubSet(source, length);
                subSet[length - 1] = source[i];
                result.Add(subSet);
            }

            var newSource = CopyShifted(source);
            
            GetSubSets(newSource, length, result);
        }

        private int[] InitSubSet(int[] source, int length)
        {
            var result = new int[length];
            for (var i = 0; i < length - 1; i++)
            {
                result[i] = source[i];
            }

            return result;
        }

        private int[] CopyShifted(int[] source)
        {
            var newSource = new int[source.Length - 1];

            for (var i = 1; i < source.Length; i++)
            {
                newSource[i - 1] = source[i];
            }

            return newSource;
        }
        
    }
}

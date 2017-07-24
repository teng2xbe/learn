using NUnit.Framework;

namespace algo.Tests
{
    
    [TestFixture]
    public class NumberOf_SumOfN_InArray_Fixture
    {
        [Test]
        public void Given_ArrayOfIntegerAndANumberAsSum_Returns_NumberOfTheSum1()
        {
            var array = new[] {1, 2, 2, 2, 5, 6, 7, 8, 3, 9, 8, 4, 7, 4};
            var findSum = 10;

            var result = SumOccurrence.FindNumberOfOccurrence(array, findSum);
            Assert.AreEqual(5, result);
        }

        [Test]
        public void Given_ArrayOfIntegerAndANumberAsSum_Returns_NumberOfTheSum2()
        {
            var array = new[] { 1, 2, 3};
            var findSum = 10;

            var result = SumOccurrence.FindNumberOfOccurrence(array, findSum);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Given_ArrayOfIntegerAndANumberAsSum_Returns_NumberOfTheSum3()
        {
            var array = new[] { 1,2,3,1,2,3,1,2,3,7,8,9,7,8,9 };
            var findSum = 10;

            var result = SumOccurrence.FindNumberOfOccurrence(array, findSum);
            Assert.AreEqual(6, result);
        }

        [Test]
        public void Given_ArrayOfIntegerAndANumberAsSum_Returns_NumberOfTheSum4()
        {
            var array = new[] { 5,5,5,5,5 };
            var findSum = 10;

            var result = SumOccurrence.FindNumberOfOccurrence(array, findSum);
            Assert.AreEqual(2, result);
        }
    }
}

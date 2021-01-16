using NUnit.Framework;
using Task_2;

namespace Task_2_Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Search_Binary__search_every_element_in_array__returns_correct_index()
        {
            int[] expectedArray = new int[] { 1, 4, 23, 45, 78, 97, 134, 157, 212, 345, 489 };
            for(int it = 0; it < expectedArray.Length; it++)
            {
                int expectedIndex= it;
                int actualIndex = Search.Binary(expectedArray, expectedArray[it]);
                Assert.AreEqual(expectedIndex, actualIndex);
            }
        }

        [Test]
        public void Search_Binary__search_missing_value__returns_not_found_index()
        {
            int[] expectedArray = new int[] { 1, 4, 23, 45, 78, 97, 134, 157, 212, 345, 489 };
            int missingValue = 54;
            int expectedIndex = -1;
            int actualIndex = Search.Binary(expectedArray, missingValue);
            Assert.AreEqual(expectedIndex, actualIndex);
        }

        [Test]
        public void Search_Binary__search_in_empty_array__returns_not_found_index()
        {
            int[] expectedArray = new int[] {};
            int expectedValue = 54;
            int expectedIndex = -1;
            int actualIndex = Search.Binary(expectedArray, expectedValue);
            Assert.AreEqual(expectedIndex, actualIndex);
        }
    }
}
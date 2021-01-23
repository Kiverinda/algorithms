using NUnit.Framework;
using Task_1;

namespace Task_1_Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Equals_twolinkedlist_true()
        {
            int[] expectedValue = new int[] { 2, 4, 12, 54, 49, 90, 123 };
            LinkedList expectedList = new LinkedList(expectedValue);
            LinkedList actualdList = new LinkedList(expectedValue);
            Assert.IsTrue(expectedList.Equals(actualdList));
        }

        [Test]
        public void Equals_twolinkedlist_false()
        {
            int[] expectedValue = new int[] { 2, 4, 12, 54, 49, 90, 123 };
            int[] actualValue = new int[] { 2, 4, 49, 90, 123 };
            LinkedList expectedList = new LinkedList(expectedValue);
            LinkedList actualdList = new LinkedList(actualValue);
            Assert.IsFalse(expectedList.Equals(actualdList));
        }

        [Test]
        public void Equals_linkedlist_and_array_true()
        {
            int[] arrayValue = new int[] { 2, 4, 12, 54, 49, 90, 123 };
            LinkedList expectedList = new LinkedList(arrayValue);
            Assert.IsTrue(expectedList.Equals(arrayValue));
        }

        [Test]
        public void Equals_linkedlist_and_array_false()
        {
            int[] expectedValue = new int[] { 2, 4, 12, 54, 49, 90, 123 };
            int[] actualValue = new int[] { 2, 4, 49, 90, 123 };
            LinkedList expectedList = new LinkedList(expectedValue);
            Assert.IsFalse(expectedList.Equals(actualValue));
        }

        [Test]
        public void Created_linkedlist_47_value()
        {
            int expectedValue = 47;
            LinkedList actualList = new LinkedList(expectedValue);
            int actualValue = actualList.FirstNode.Value;
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void AddNodeAfter_firstnode_value()
        {
            int[] arrayValue = new int[] { 2, 4, 12, 54, 49, 90, 123 };
            LinkedList actualList = new LinkedList(arrayValue);
            int expectedValue = 34;
            actualList.AddNodeAfter(actualList.FirstNode, expectedValue);
            int actualValue = actualList.FirstNode.NextNode.Value;
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void AddNodeAfter_lastnode_value()
        {
            int[] arrayValue = new int[] { 2, 4, 12, 54, 49, 90, 123 };
            LinkedList actualList = new LinkedList(arrayValue);
            int expectedValue = 34;
            actualList.AddNodeAfter(actualList.LastNode, expectedValue);
            int actualValue = actualList.LastNode.Value;
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void AddNodeAfter_findnode_49()
        {
            int[] arrayValue = new int[] { 2, 4, 12, 54, 49, 90, 123, 67, 345, 46, 85 };
            LinkedList actualList = new LinkedList(arrayValue);
            int expectedValue = 34;
            actualList.AddNodeAfter(actualList.FindNode(49), expectedValue);
            int actualValue = actualList.FindNode(49).NextNode.Value;
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void Count()
        {
            int[] arrayValue = new int[] { 2, 4, 12, 54, 49, 90, 123, 67, 345, 46, 85 };
            int expectedCount = arrayValue.Length;
            LinkedList actualList = new LinkedList(arrayValue);
            int actualCount = actualList.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void RemoveNode_bynode_startnode()
        {
            int[] arrayValue = new int[] { 2, 4, 12, 54, 49, 90, 123, 67, 345, 46, 85 };
            LinkedList expectedList = new LinkedList(4, 12, 54, 49, 90, 123, 67, 345, 46, 85);
            LinkedList actualList = new LinkedList(arrayValue);
            actualList.RemoveNode(actualList.FirstNode);
            Assert.IsTrue(expectedList.Equals(actualList));
        }

        [Test]
        public void RemoveNode_bynode_endnode()
        {
            int[] arrayValue = new int[] { 2, 4, 12, 54, 49, 90, 123, 67, 345, 46, 85 };
            LinkedList expectedList = new LinkedList(2, 4, 12, 54, 49, 90, 123, 67, 345, 46);
            LinkedList actualList = new LinkedList(arrayValue);
            actualList.RemoveNode(actualList.LastNode);
            Assert.IsTrue(expectedList.Equals(actualList));
        }

        [Test]
        public void RemoveNode_bynode_middlenode()
        {
            int[] arrayValue = new int[] { 2, 4, 12, 54, 49, 90, 123, 67, 345, 46, 85 };
            LinkedList expectedList = new LinkedList(2, 4, 12, 54, 49, 123, 67, 345, 46, 85);
            LinkedList actualList = new LinkedList(arrayValue);
            actualList.RemoveNode(actualList.FindNode(90));
            Assert.IsTrue(expectedList.Equals(actualList));
        }

        [Test]
        public void RemoveNode_byindex_startnode()
        {
            int[] arrayValue = new int[] { 2, 4, 12, 54, 49, 90, 123, 67, 345, 46, 85 };
            LinkedList expectedList = new LinkedList(4, 12, 54, 49, 90, 123, 67, 345, 46, 85);
            LinkedList actualList = new LinkedList(arrayValue);
            actualList.RemoveNode(1);
            Assert.IsTrue(expectedList.Equals(actualList));
        }

        [Test]
        public void RemoveNode_byindex_endnode()
        {
            int[] arrayValue = new int[] { 2, 4, 12, 54, 49, 90, 123, 67, 345, 46, 85 };
            LinkedList expectedList = new LinkedList(2, 4, 12, 54, 49, 90, 123, 67, 345, 46);
            LinkedList actualList = new LinkedList(arrayValue);
            actualList.RemoveNode(actualList.Count);
            Assert.IsTrue(expectedList.Equals(actualList));
        }

        [Test]
        public void RemoveNode_byindex_middlenode()
        {
            int[] arrayValue = new int[] { 2, 4, 12, 54, 49, 90, 123, 67, 345, 46, 85 };
            LinkedList expectedList = new LinkedList(2, 4, 12, 54, 49, 123, 67, 345, 46, 85);
            LinkedList actualList = new LinkedList(arrayValue);
            actualList.RemoveNode(6);
            Assert.IsTrue(expectedList.Equals(actualList));
        }

    }
}
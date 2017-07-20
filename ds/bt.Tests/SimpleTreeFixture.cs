using NUnit.Framework;

namespace bt.Tests
{
    [TestFixture]
    public class SimpleTreeFixture
    {
        [Test]
        public void CreateTreeWithInitialHeadNode()
        {
            
            var bt = new SimpleTree(new SimpleNode {Data = 100});
            Assert.AreEqual(100, bt.GetNode(100).Data);
        }

        [Test]
        public void AddSorted_AddedTheNodeInOrder()
        {
            var bt = new SimpleTree(new SimpleNode { Data = 100 });
            bt.AddSorted(new SimpleNode {Data = 75});
            bt.AddSorted(new SimpleNode { Data = 155 });
            bt.AddSorted(new SimpleNode { Data = 125 });
            bt.AddSorted(new SimpleNode { Data = 15 });
            bt.AddSorted(new SimpleNode { Data = 85 });
            Assert.AreEqual(100, bt.GetNode(100).Data);
        }
    }
}

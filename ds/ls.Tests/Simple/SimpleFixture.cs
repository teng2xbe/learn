using System.Collections.Generic;
using ls.Simple;
using NUnit.Framework;

namespace ls.Tests.Simple
{
    [TestFixture]
    public class SimpleFixture
    {
        [Test]
        public void AppendLast_ShouldAddNodeAtTheEnd()
        {
            var ls = new SimpleLinkedList();
            ls.AppendLast(new SimpleNode { Data = 1 });
            ls.AppendLast(new SimpleNode { Data = 2 });
            ls.AppendLast(new SimpleNode { Data = 3 });

            var nodeList = ls.GetList();
            Assert.AreEqual(1, nodeList[0].Data);
            Assert.AreEqual(2, nodeList[1].Data);
            Assert.AreEqual(3, nodeList[2].Data);
        }

        [Test]
        public void InsertFirst_ShouldInsertAtTheStartOfList()
        {
            var ls = new SimpleLinkedList();
            ls.InsertFirst(new SimpleNode { Data = 1 });
            ls.InsertFirst(new SimpleNode { Data = 2 });
            ls.InsertFirst(new SimpleNode { Data = 3 });

            var nodeList = ls.GetList();
            Assert.AreEqual(3, nodeList[0].Data);
            Assert.AreEqual(2, nodeList[1].Data);
            Assert.AreEqual(1, nodeList[2].Data);
        }

        [Test]
        public void InsertAfter_ShouldInsertAfterTheReferenceNode()
        {
            var ls = new SimpleLinkedList();
            var refNode = new SimpleNode {Data = 2};
            ls.AppendLast(new SimpleNode { Data = 1 });
            ls.AppendLast(refNode);
            ls.AppendLast(new SimpleNode { Data = 3 });

            ls.InsertAfter(refNode, new SimpleNode {Data = 4});
            var nodeList = ls.GetList();
            Assert.AreEqual(1, nodeList[0].Data);
            Assert.AreEqual(2, nodeList[1].Data);
            Assert.AreEqual(4, nodeList[2].Data);
            Assert.AreEqual(3, nodeList[3].Data);
        }
    }
}

using System.Collections.Generic;

namespace ls.Simple
{
    public class SimpleLinkedList
    {
        private SimpleNode head;
        public SimpleLinkedList()
        {
            head = null;
        }

        public IList<SimpleNode> GetList()
        {
            var result = new List<SimpleNode>();
            
            return GetList(result, head);
        }

        private IList<SimpleNode> GetList(IList<SimpleNode> list, SimpleNode currentNode)
        {
            if (currentNode == null)
            {
                return list;
            }
            list.Add(currentNode);

            return GetList(list, currentNode.NextNode);            
        }

        public void AppendLast(SimpleNode node)
        {
            if (head == null)
            {
                head = node;
            }
            else
            {
                AppendLast(head, node);
            }
        }

        private void AppendLast(SimpleNode current, SimpleNode node)
        {
            if (current.NextNode == null)
            {
                current.NextNode = node;
            }
            else
            {
                AppendLast(current.NextNode, node);
            }
        }

        public void InsertFirst(SimpleNode node)
        {
            if (head == null)
            {
                head = node;
            }
            else
            {
                var tempNode = head;
                head = node;
                node.NextNode = tempNode;
            }
        }
    }
}

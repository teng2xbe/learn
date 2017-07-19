using System;
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

        public void InsertAfter(SimpleNode refNode, SimpleNode node)
        {
            if (head == null)
            {
                throw new ArgumentException("List is empty!");
            }
            
            var currentNode = FindNode(head, refNode);
            if (currentNode == null)
            {
                throw new ArgumentException("Cannot find reference node!");
            }
            else
            {
                node.NextNode = currentNode.NextNode;
                currentNode.NextNode = node;                
            }

        }

        public void InsertBefore(SimpleNode refNode, SimpleNode node)
        {
            if (head == null)
            {
                throw new ArgumentException("List is empty!");
            }
            var currentNode = FindNode(head, refNode);
            var parentNode = FindParentNode(head, refNode);
            if (parentNode == null)
            {
                throw new ArgumentException("Cannot find reference node!");
            }
            node.NextNode = currentNode;
            parentNode.NextNode = node;
        }

        public SimpleNode FindParentNode(SimpleNode current, SimpleNode nodeToFind)
        {
            if (current == null)
            {
                return null;
            }

            if (IsEqual(current.NextNode, nodeToFind))
            {
                return current;
            }

            return FindNode(current.NextNode, nodeToFind);
        }

        public SimpleNode FindNode(SimpleNode current, SimpleNode node)
        {
            if (current == null)
            {
                return null;
            }

            if (IsEqual(current, node))
            {
                return current;
            }
            
            return FindNode(current.NextNode, node);            
        }

        public bool IsEqual(SimpleNode node1, SimpleNode node2)
        {
            return node1.Data == node2.Data;
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

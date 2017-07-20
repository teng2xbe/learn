namespace bt
{
    public class SimpleTree
    {
        private SimpleNode head;

        public SimpleTree()
        {
            head = null;
        }

        public SimpleTree(SimpleNode head)
        {
            this.head = head;
        }

        public SimpleNode GetNode(int data)
        {
            return GetNode(head, data);
        }

        private SimpleNode GetNode(SimpleNode current, int data)
        {
            if (data > head.Data)
            {
                return GetNode(head.RigthNode, data);
            }

            if (data < head.Data)
            {
                return GetNode(head.LeftNode, data);
            }
            
            return current;
        }

        public void AddSorted(SimpleNode node)
        {
            if (head == null)
            {
                head = node;
            }
            else
            {
                AddSorted(head, node);
            }            
        }


        private void AddSorted(SimpleNode current, SimpleNode node)
        {
            if (node.Data > current.Data)
            {
                if (current.RigthNode == null)
                {
                    current.RigthNode = node;
                }
                else
                {
                    AddSorted(current.RigthNode, node);
                }                
            }
            else if (node.Data < current.Data)
            {
                if (current.LeftNode == null)
                {
                    current.LeftNode = node;
                }
                else
                {
                    AddSorted(current.LeftNode, node);
                }                
            }
            
        }
    }
}

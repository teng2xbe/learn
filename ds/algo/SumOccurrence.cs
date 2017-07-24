namespace algo
{
    public static class SumOccurrence
    {
        public static int FindNumberOfOccurrence(int[] array, int sumToFind)
        {
            var bt = new Tree(array[0], sumToFind);
            for (var i = 1; i < array.Length; i++)
            {
                bt.AddNode(array[i]);
            }
            return bt.GetNumberOfSum();
        }

    }

    public class Tree
    {
        private Node head;
        private int sum;
        

        public Tree(int firsData, int sum)
        {
            head = new Node {Data = firsData};
            this.sum = sum;
        }

        public void AddNode(int data)
        {
            AddNode(head, data);
        }

        private void AddNode(Node current, int data)
        {
            if (current.Data == data)
            {
                current.Counter++;
                return;
            }
            if (current.Data + data == sum)
            {
                if (current.Left == null)
                {
                    current.Left = new Node { Data = data };
                    return;
                }
                AddNode(current.Left, data);
            }
            else
            {
                if (current.Right == null)
                {
                    current.Right = new Node { Data = data };
                    return;
                }
                AddNode(current.Right, data);
            }            
        }

        public int GetNumberOfSum()
        {
            var current = head;
            var depth = GetNumberOfSum(current);
            while (current.Right != null)
            {
                depth += GetNumberOfSum(current.Right);
                current = current.Right;
            }

            return depth;
        }

        private int GetNumberOfSum(Node node)
        {
            if (node.Left != null)
            {
                if (node.Counter == 0)
                {
                    return 1;
                }
                return 1 + node.Left.Counter;
            }
            if (node.Data*2 == sum)
            {
                return node.Counter/2;
            }
            return 0;
        }
    }

    public class Node
    {
        public int Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int Counter { get; set; }
    }
}

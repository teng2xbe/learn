namespace ls.Simple
{
    public class SimpleLinkedList
    {
        private SimpleNode head;
        public SimpleLinkedList()
        {
            head = null;
        }

        public void AppendNode(SimpleNode node)
        {
            if (head == null)
                head = node;
            else
            {
                head.NextNode = node;                
            }
        }
    }
}

using System.Collections.Generic;

namespace ls.Generic
{
    public class GenericList<T>
    {
        private GenericNode<T> head;

        public GenericList()
        {
            head = null;
        }

        public IList<T> ToList()
        {
            var list = new List<T>();

            GetList(head, list);

            return list;
        }

        private IList<T> GetList(GenericNode<T> current, IList<T> result)
        {
            if (current.Node == null)
            {
                result.Add(current.Data);
                return result;
            }
            
            result.Add(current.Data);
            return GetList(current.Node, result);
        }


        public void AppendLast(T data)
        {
            if (head == null)
            {
                head = new GenericNode<T> {Data = data};
            }
            else
            {
                AppendLast(head, data);
            }            
        }

        private void AppendLast(GenericNode<T> current, T data)
        {
            if (current.Node == null)
            {
                var tempNode = new GenericNode<T> {Data = data};
                current.Node = tempNode;
            }
            else
            {
                AppendLast(current.Node, data);
            }
        }
    }
}

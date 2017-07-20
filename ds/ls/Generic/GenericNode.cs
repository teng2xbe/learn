namespace ls.Generic
{
    public class GenericNode<T>
    {
        public T Data { get; set; }
        public GenericNode<T> Node { get; set; }
    }
}

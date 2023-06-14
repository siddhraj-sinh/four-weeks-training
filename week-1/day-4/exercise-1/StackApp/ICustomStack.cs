namespace StackApp
{
    internal interface ICustomStack<T>
    {
        void Push(T item);
        T Pop();
        bool IsEmpty();
    }

    public class Stack<T> : ICustomStack<T>
    {


        private class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }
            public Node(T data)
            {
                Data = data;
                Next = null;
            }
        }
        private Node top;

        public void Push(T item)
        {
            Node newNode = new Node(item);
            newNode.Next = top;
            top = newNode;

        }

        public T Pop()
        {
            T data = top.Data;
            top = top.Next;
            return data;
        }
        public bool IsEmpty() {
            return top == null;
        }
    }
}

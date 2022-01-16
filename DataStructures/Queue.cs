namespace DataStructures
{
    interface IQueue
    {
        // insert a new string onto queue
        void Enqueue(string item);

        // remove and return the string
        string Dequeue();

        // least recently added
        bool IsEmpty();
    }

    public class Queue : IQueue
    {
        private Node first, last;

        public string Dequeue()
        {
            var value = first.Item;
            first = first.Next;
            if (IsEmpty())
            {
                last = null;
            }

            return value;
        }

        public void Enqueue(string item)
        {
            var oldLast = last;
            last = new Node { Item = item };
            if (IsEmpty())
            {
                first = last;
            }
            else oldLast.Next = last;
        }

        public bool IsEmpty()
        {
            return first == null;
        }
    }
}

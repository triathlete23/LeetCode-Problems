namespace DataStructures
{
    public class LinkedList
    {
        private Node first;

        public LinkedList()
        {
            first = null;
        }

        public void Push(String item)
        {
            var oldFirst = first;
            first = new Node
            {
                Item = item,
                Next = oldFirst
            };
        }

        public string Pop()
        {
            var item = first.Item;
            first = first.Next;
            return item;
        }

        public bool IsEmpty()
        {
            return first == null;
        }
    }
}
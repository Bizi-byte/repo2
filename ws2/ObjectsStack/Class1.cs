namespace Stack
{
    public class ObjectStack
    {
        readonly object[] data;
        ulong next_item;
        readonly ulong capacity;
        public ObjectStack(ulong size = 10)
        {
            capacity = size;
            data = new object[size];
            next_item = 0;
        }

        public bool Push(object element)
        {
            bool pushed = false;
            if (next_item < capacity)
            {
                data[next_item++] = element;
                pushed = true;
            }

            return pushed;
        }
        public bool Pop()
        {
            bool popped = false;
            if (next_item > 0)
            {
                --next_item;
                popped = true;
            }

            return popped;
        }
        public object Peek()
        {
            return data[next_item - 1];
        }
        public bool IsEmpty()
        {
            return (0 == next_item);
        }
        public void Clear()
        {
            next_item = 0;
        }
    }
        public class GenericStack<T>
    {
        readonly T[] data;
        ulong next_item;
        readonly ulong capacity;
        public GenericStack(ulong size = 10)
        {
            capacity = size;
            data = new T[size];
            next_item = 0;
        }
        public bool Push(T element)
        {
            bool pushed = false;
            if (next_item < capacity)
            {
                data[next_item++] = element;
                pushed = true;
            }

            return pushed;
        }
        public bool Pop()
        {
            bool popped = false;
            if (next_item > 0)
            {
                --next_item;
                popped = true;
            }

            return popped;
        }
        public T Peek()
        {
            return data[next_item - 1];
        }
        public bool IsEmpty()
        {
            return (0 == next_item);
        }
        public void Clear()
        {
            next_item = 0;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericLinkList
{
    
    public class Node<T>
    {
        public T data;
        public Node<T> next;
        /// <summary>
        /// creates a linked list node which stores the given data and connects 
        /// it to the given node
        /// </summary>
        /// <param name="item_data"></param>
        /// <param name="next_node"></param>
        public Node(T item_data, Node<T> next_node)
        {
            data = item_data;
            next = next_node;
        }
        /// <summary>
        /// getter for data stored in node
        /// </summary>
        /// <returns> data stored in current node </returns>
        public T GetData()
        {
            return data;
        }
        /// <summary>
        /// connectd the current node to the given node
        /// </summary>
        /// <param name="to_connect"></param>
        public void SetNext(Node<T> to_connect)
        {
            next = to_connect;
        }

    }

    /// <summary>
    /// main class to create and manage the generic linked list
    /// </summary>
    /// <remarks>
    /// has Push, Pop, IsEmpty, Clear, Head, and Count methods. 
    /// allows using of foreach
    /// <example>
    /// <code>
    /// foreach(Node n in list)
    /// {...}
    /// </code>
    /// </example>
    /// </remarks>
    public class LinkList<T> : IEnumerable
    {
        Node<T> head;
        ulong size;


        /// <include file='XMLFile1.doc' path='docs/members[@name="LinkedList"]/LinkList/summary'/>"
        public LinkList()
        {
            size = 0;
            head = null;
        }

        /// <include file='XMLFile1.doc' path='docs/members[@name="LinkedList"]/LinkList'/>"
        public bool Push(T node_data)
        {
            var node = new Node<T>(node_data, head);
            node.SetNext(head);
            head = node;
            ++size;
            return true;
        }
        /// <summary>
        /// removes the last added data from the list
        /// </summary>
        public void Pop()
        {
            head = head.next;
            --size;
        }
        /// <summary>
        /// method to check if list is empty
        /// </summary>
        /// <returns>
        /// boolean value, true represents list is empty 
        /// </returns>
        public bool IsEmpty()
        {
            return (0 == size);
        }
        /// <summary>
        /// clears the list from all data
        /// </summary>
        public void Clear()
        {
            while (0 < size)
            {
                Pop();
            }
        }
        /// <summary>
        /// method to get the last added data
        /// </summary>
        /// <returns></returns>
        public T Head()
        {
            return head.GetData();
        }
        /// <summary>
        /// get the number of elements in list
        /// </summary>
        /// <returns> number of elements in list as ulong</returns>
        public ulong Count()
        {
            return size;
        }
        /// <summary>
        /// method to get the first node of the list
        /// </summary>
        /// <returns> the first node in the list </returns>
        public Node<T> GetHead()
        {
            return head;
        }
        /// <summary>
        /// get an inumerator to the list
        /// </summary>
        /// <returns> list enumerator </returns>

        public IEnumerator GetEnumerator()
        {
            return (new ListEnumt<T>(this));
        }
    }

    
        

        public class ListEnumt<T> : IEnumerator
        {
            private Node<T> current;
            private Node<T> head;

            public ListEnumt(LinkList<T> list)
            {
                current = list.GetHead();
            }

            public bool MoveNext()
            {
                if (current.next == null)
                {
                    return false;
                }
                else
                {
                    current = current.next;
                }
                return true;
            }

            public void Reset()
            {
                current = head;
            }

            public Node<T> Current
            {
                get { return current; }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

        }
    
}



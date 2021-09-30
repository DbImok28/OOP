using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public class ListNode<T>
    {
        public ListNode(T data)
        {
            Data = data;
        }
        public ListNode<T> next = null;
        public T Data;
    }
}

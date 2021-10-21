using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace lab8
{
    public class MyList<T>// where T : class
    {
        public static MyList<T> operator+(MyList<T> a, MyList<T> b)
        {
            MyList<T> result = new MyList<T>();
            var item = a.head;

            //head
            result.head = new ListNode<T>(item.Data);
            if (item.next == null)
            {
                return result;
            }
            item = item.next;

            //add
            var resultItem = result.head;

            while(item != null)
            {
                resultItem.next = new ListNode<T>(item.Data);
                resultItem = resultItem.next;
                item = item.next;
            }
            item = b.head;
            while (item != null)
            {
                resultItem.next = new ListNode<T>(item.Data);
                resultItem = resultItem.next;
                item = item.next;
            }
            return result;
        }
        public static bool operator==(MyList<T> a, MyList<T> b)
        {
            var itemA = a.head;
            var itemB = b.head;

            while (itemA != null || itemB != null)
            {
                if(!itemA.Data.Equals(itemB.Data))
                {
                    return false;
                }

                itemA = itemA.next;
                itemB = itemB.next;
            }
            if(itemA != null && itemB != null)
            {
                return true;
            }
            return false;
        }
        public static bool operator!=(MyList<T> a, MyList<T> b)
        {
            return !(a == b);
        }   
        public MyList()
        {

        }
        public void Add(T data)
        {
            if (head == null)
            {
                head = new ListNode<T>(data);
                return;
            }
            var last = head;
            while (last.next != null)
            {
                last = last.next;
            }
            last.next = new ListNode<T>(data);
        }
        public void Add(MyList<T> b)
        {
            if (b is null)
            {
                throw new ArgumentNullException(nameof(b));
            }
            if (b.head == null)
            {
                return;
            }
            var itemForB = b.head;
            var last = head;
            if (last == null)
            {
                last = new ListNode<T>(itemForB.Data);
                itemForB = itemForB.next;
                if (itemForB == null)
                {
                    return;
                }
            }
            else
            {
                while (last.next != null)
                {
                    last = last.next;
                }
            }


            // Copy
            do
            {
                last.next = new ListNode<T>(itemForB.Data);
                itemForB = itemForB.next;
                last = last.next;
            } while (itemForB != null);
        }
        public void Remove(T data)
        {
            if (head.Data.Equals(data))
            {
                head = head.next;
                return;
            }
            var last = head;
            while (last.next != null)
            {
                if (last.next.Data.Equals(data))
                {
                    last = last.next.next;
                    return;
                }
                last = last.next;
            }
        }
        public bool Find(out T result, Predicate<T> pred)
        {
            var item = head;
            while (item != null)
            {
                if(pred(item.Data))
                {
                    result = item.Data;
                    return true;
                }
                item = item.next;
            }
            result = default(T);
            return false;
        }
        public void Print()
        {
            var item = head;
            Console.Write("{");
            while (item != null)
            {
                Console.Write(item.Data);
                item = item.next;
                if (item != null)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine("}");
        }
        public int Count { get {
                int count = 0;
                var item = head;
                while (item != null)
                {
                    count++;
                    item = item.next;
                }
                return count;
            } 
        }
        public T this[int index]
        {
            get
            {
                var item = head;
                for (int i = 0; i < index; i++)
                {
                    if (item == null)
                    {
                        throw new IndexOutOfRangeException("index > maxIndex");
                    }
                    item = item.next;
                }
                return item.Data;
            }
            set
            {
                var item = head;
                for (int i = 0; i < index; i++)
                {
                    if (item == null)
                    {
                        throw new IndexOutOfRangeException("index > maxIndex");
                    }
                    item = item.next;
                }
                item.Data = value;
            }
        }
        public bool TryGet(out T result, int i)
        {
            try
            {
                result = this[i];
                return true;
            }
            catch
            {
                result = default(T);
                return false;
            }
        }
        public void Save(string path)
        {
            using (var f = new StreamWriter(path))
            {
                var item = head;
                while (item != null)
                {
                    if (item != null)
                    {
                        f.WriteLine(item.Data);
                    }
                    item = item.next;
                }
            }
        }
        public void Load(string path, Func<string, T> toData)
        {
            using (var f = new StreamReader(path))
            {
                while (!f.EndOfStream)
                {
                    Add(toData(f.ReadLine()));
                }
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            var item = head;
            sb.Append("{");
            while (item != null)
            {
                sb.Append(item.Data.ToString());
                item = item.next;
                if (item != null)
                {
                    sb.Append(", ");
                }
            }
            sb.Append("}");
            return sb.ToString();
        }
        private ListNode<T> head;
    }
}

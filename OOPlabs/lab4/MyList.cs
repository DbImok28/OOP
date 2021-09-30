using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    /*
        Класс - однонаправленный список List. Дополнительно
        перегрузить следующие операции: ! – инверсия элементов; + - объединить два списка; = = - проверка на равенство; < - добавление одного списка к другому.
        Методы расширения:
        1) Усечение строки до заданной длины
        2) Сумма элементов списка
    */
    public class MyList<T>
    {
        public class Owner
        {
            public Owner(int iD = 0, string outhorName = "none", string organisationName = "none")
            {
                if (string.IsNullOrWhiteSpace(outhorName))
                {
                    throw new ArgumentException($"'{nameof(outhorName)}' cannot be null or whitespace.", nameof(outhorName));
                }

                if (string.IsNullOrWhiteSpace(organisationName))
                {
                    throw new ArgumentException($"'{nameof(organisationName)}' cannot be null or whitespace.", nameof(organisationName));
                }

                ID = iD;
                OuthorName = outhorName;
                OrganisationName = organisationName;
            }
            int ID;
            string OuthorName;
            string OrganisationName;
        }
        public class Date
        {
            DateTime CreationTime = DateTime.Now;
        }
        //public static class StatisticOperation
        //{
        //}
        //public static MyList<T> operator!(MyList<T> a)
        //{
        //    var item = a.head;
        //    while (item != null)
        //    {
        //        item.Data = !item.Data;
        //        item = item.next;
        //    }
        //}
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
        public static bool operator<(MyList<T> a, MyList<T> b)
        {
            a.Add(b);
            return true;
        }
        public static bool operator>(MyList<T> a, MyList<T> b)
        {
            b.Add(a);
            return true;
        }
            
        
        public MyList(Owner owner)
        {
            ListOwner = owner;
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
                for (int i = 0; i < index ; i++)
                {
                    if(item == null)
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
        /*
        public static MyList<T> operator +(MyList<T> a)
        {
            return a;
        }*/
        //public static bool operator <(MyList<T> a, MyList<T> b)
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

        private ListNode<T> head;
        public Owner ListOwner { get; private set; }
        public Date CreationTime { get; private set; }
    }
}

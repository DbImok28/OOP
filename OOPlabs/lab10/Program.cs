using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            var rs = new InternetResource<int>(1, 2, 3, 4);
            rs.Add(8);
            rs.Remove(2);
            Console.WriteLine(rs);
            
            //-----

            var dic = new ConcurrentDictionary<int, InternetResource<string>>();
            dic.TryAdd(9, new InternetResource<string>("hello", "123"));
            dic.TryAdd(1, new InternetResource<string>("43werfdsa", "123", "asdfv", "12dfsg", "fdsg5"));
            dic.TryAdd(5, new InternetResource<string>("123", "asdfv", "asdfv"));
            dic.TryAdd(0, new InternetResource<string>("fgdg", "asdgasg", "sadfg4"));
            dic.TryAdd(2, new InternetResource<string>("vhdfjh", "asdfasf"));
            dic.TryAdd(3, new InternetResource<string>("sdrgfd", "1asdf23", "asdfv"));

            foreach (var item in dic)
            {
                Console.WriteLine(item.ToString());
            }
            if (dic.TryRemove(0, out var resource))
            {
                Console.WriteLine(resource);
            }
            if (dic.TryGetValue(2, out var resource2))
            {
                Console.WriteLine(resource2);
            }

            //-----

            var set = new HashSet<string>(StringComparer.CurrentCulture);
            Console.WriteLine();
            foreach (var items in dic)
            {
                foreach (var item in items.Value)
                {
                    set.Add(item);
                }
            }

            foreach (var item in set)
            {
                Console.WriteLine(item.ToString());
            }
            if(set.TryGetValue("123", out string value))
            {
                Console.WriteLine(value);
            }

            //-----

            var ObservCol = new ObservableCollection<List<int>,int>(new List<int>());

            var ObservDic = new ObservableDictionary<ConcurrentDictionary<int, string>, int, string>(new ConcurrentDictionary<int, string>());
            ObservDic.OnChange += () => { Console.WriteLine("Changed"); };
            ObservDic.Add(1, "h1");
            ObservDic.Add(3, "h3");
            ObservDic.Add(2, "h2");
            ObservDic.Remove(2);
            Console.ReadKey();
        }
    }
}

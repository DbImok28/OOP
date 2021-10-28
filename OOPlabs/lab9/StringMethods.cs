using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    public static class StringMethods
    {    
        public static string RemoveIf(this string str, Predicate<char> fun)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in str)
            {
                if(!fun(item))
                {
                    sb.Append(item);
                }
            }
            return sb.ToString();
        }
        public static string AddSymbol(this string str, Func<char, char?> fun)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in str)
            {
                sb.Append(item);
                var newSymbol = fun(item);
                if (newSymbol.HasValue)
                {
                    sb.Append(newSymbol);
                }
            }
            return sb.ToString();
        }
        public static void IsHaveSymbol(this string str, char symbol, Action action)
        {
            foreach (var item in str)
            {
                if (item == symbol)
                {
                    action.Invoke();
                }
            }
        }
        public static string ToUpperIf(this string str, Predicate<char> fun)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in str)
            {
                if (fun(item))
                {
                    sb.Append(char.ToUpper(item));
                }
                else
                {
                    sb.Append(item);
                }
            }
            return sb.ToString();
        }
        public static string ToLowerIf(this string str, Predicate<char> fun)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in str)
            {
                if (fun(item))
                {
                    sb.Append(char.ToLower(item));
                }
                else
                {
                    sb.Append(item);
                }
            }
            return sb.ToString();
        }
    }
}

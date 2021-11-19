using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    public static class Reflector
    {
        /*
         * a. Определение имени сборки, в которой определен класс; 
         * b. есть ли публичные конструкторы; 
         * c. извлекает все общедоступные публичные методы класса (возвращает IEnumerable<string>); 
         * d. получает информацию о полях и свойствах класса (возвращает IEnumerable<string>); 
         * e. получает все реализованные классом интерфейсы (возвращает IEnumerable<string>); 
         * f. выводит по имени класса имена методов, которые содержат заданный (пользователем) тип параметра (имя класса передается в качестве аргумента); 
         * g. метод Invoke, который вызывает метод класса, при этом значения для его параметров необходимо 
         *      1) прочитать из текстового файла (имя класса и имя метода передаются в качестве аргументов) 
         *      2) сгенерировать, используя генератор значений для каждого типа. Параметрами метода Invoke должны быть : объект, имя метода, массив параметров.
         */
        public static string AssemblyName(string className = "System.DateTime")
        {
            Type type = Type.GetType(className);
            return type.Assembly.FullName;
        }
        public static bool HavePublicConstructor(string className = "System.DateTime")
        {
            Type type = Type.GetType(className);
            foreach (var item in type.GetConstructors())
            {
                if (item.IsPublic)
                {
                    return true;
                }
            }
            return false;
        }
        public static IEnumerable<string> GetPublicMethods(string className = "System.DateTime")
        {
            Type type = Type.GetType(className);
            var result = new List<string>();
            foreach (var item in type.GetMethods())
            {
                if(item.IsPublic)
                {
                    result.Add(item.Name);
                }
            }
            return result;
        }
        public static IEnumerable<string> GetMethodsInfo(string className = "System.DateTime")
        {
            Type type = Type.GetType(className);
            var result = new List<string>();
            foreach (var item in type.GetMethods())
            {
                result.Add(item.Name);
            }
            foreach (var item in type.GetProperties())
            {
                result.Add(item.Name);
            }
            return result;
        }
        public static IEnumerable<string> GetImplementedInterfaces(string className = "System.DateTime")
        {
            Type type = Type.GetType(className);

            var result = new List<string>();
            foreach (var item in type.GetInterfaces())
            {
                result.Add(item.Name);
            }
            return result;
        }
        public static IEnumerable<string> MethodsRetunedType(string className, Type returnType)
        {
            Type type = Type.GetType(className);
            var result = new List<string>();
            foreach (var item in type.GetMethods())
            {
                if(item.ReturnType == returnType)
                    result.Add(item.Name);
            }
            return result;
        }
        public static void LoadAndInvoke(object obj, string methodName, string path)
        {
            var method = obj.GetType().GetMethod(methodName);
            var args = new List<string>();
            using (var f = new StreamReader(path))
            {
                while (!f.EndOfStream)
                {
                    args.Add(f.ReadLine());
                }
            }
            method.Invoke(obj, args.ToArray());
        }
        public static void InvokeMethod(object obj, string methodName, params object[] args)
        {
            var method = obj.GetType().GetMethod(methodName);
            method.Invoke(obj, args);
        }

        public static void AnalyzeAndSave(string className = "System.DateTime", string path = "reflector.txt")
        {
            Type type = Type.GetType(className);
            using (var f = new StreamWriter(path))
            {
                
            }
        }

        public static object Create(string className)
        {
            Type type = Type.GetType(className);
            return type.GetConstructor(Type.EmptyTypes).Invoke(null);
        }
    }
}

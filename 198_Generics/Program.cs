using System;
using System.Collections.Generic;

namespace _198_Generics
{
    class Program
    {
        public class MyList<T>
        {
            T[] array = new T[0];

            public void Add(T item)
            {
                //[1, 2, 3, -4, 100, 485] + 4 bytes -> coloca um elemento na ultima posicao
                //[1, 2, 3, -4, 100, 485, _]
                Array.Resize(ref array, array.Length + 1);
                array[array.Length - 1] = item;
            }

            public T[] ToArray() => array;
        }

        static void Print<T>(T[] collection)
        {
            string content = string.Join(", ", collection);
            Console.WriteLine(content);
        }

        static void Main(string[] args)
        {
            List<int> numbers = new List<int>()
            {
                1, 2, 3, -4, 100, 485
            };

            MyList<int> myNumbers = new MyList<int>();
            myNumbers.Add(1);
            myNumbers.Add(2);
            myNumbers.Add(3);
            myNumbers.Add(-4);

            Print(numbers.ToArray());
            Print(myNumbers.ToArray());

            Console.ReadKey();
        }
    }
}

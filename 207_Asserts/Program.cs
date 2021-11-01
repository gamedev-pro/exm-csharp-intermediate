using System;
using System.Diagnostics;

namespace _207_Asserts
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.Assert(1 == 2, "1 nao deveria ser igual a dois");
            Console.ReadKey();
        }
    }
}

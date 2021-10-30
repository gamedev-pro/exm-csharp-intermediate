using System;

namespace _197_Lambda
{
    class Program
    {
        static void ExecuteWhere(int[] numbers, Func<int, bool> filter, Action<int> action)
        {
            foreach (int number in numbers)
            {
                if (filter(number))//filtro
                {
                    action(number);
                }
            }
        }

        static void Main(string[] args)
        {
            int[] numbers = new int[]
            {
                1, 2, 3, -4, 100, 485
            };

            int sumEven = 0;
            ExecuteWhere(
                numbers,
                n => n % 2 == 0,
                n => sumEven += n);

            int subtractionEven = 0;
            ExecuteWhere(
                numbers,
                n => n % 2 == 0,
                n => subtractionEven -= n);

            Console.WriteLine($"{sumEven}, {subtractionEven}");
            Console.ReadKey();
        }
    }
}
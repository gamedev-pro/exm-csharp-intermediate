using System;

namespace _206_Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int[] numbers = new int[] { 1, 3, 4 };
                Console.WriteLine(numbers[0]);
                // Console.WriteLine(numbers[5]);
                int x = 0;
                float y = 2.5f * x;

                string n = null;
                int index = n.IndexOf('2');
            }
            catch (System.IndexOutOfRangeException e)
            {
                Console.WriteLine($"Index Out of Range {e}");
            }
            catch (System.NullReferenceException e)
            {
                Console.WriteLine($"Index Out of Range {e}");
            }

            Console.ReadKey();
        }
    }
}

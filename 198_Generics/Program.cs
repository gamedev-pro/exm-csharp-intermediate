using System;

namespace _198_Generics
{
    class Program
    {
        static void ExecuteWhere<T>(T[] numbers, Func<T, bool> filter, Action<T> action)
        {
            foreach (T number in numbers)
            {
                if (filter(number))//filtro
                {
                    action(number);
                }
            }
        }

        static T DatabaseLookup<T>(string id)
        {
            return default(T);
        }

        struct Vector3 //POD 
        {
            public float X, Y, Z;

            public Vector3(float x, float y, float z)
            {
                X = x;
                Y = y;
                Z = z;
            }
        }

        static void Main(string[] args)
        {
            double[] numbers = new double[]
            {
                1, 2, 3, -4, 100, 485
            };

            double sumEven = 0;
            ExecuteWhere(
                numbers,
                n => n % 2 == 0,
                n => sumEven += n);

            Vector3[] vectors = new Vector3[]
            {
                new Vector3(1, 3, 4), new Vector3(1.3f, 5, -203.0f)
            };

            Vector3 sumVectors = new Vector3();
            ExecuteWhere(
                vectors,
                v => true,
                v => sumVectors = new Vector3(sumVectors.X + v.X, sumVectors.Y + v.Y, sumVectors.Z + v.Z));

            float data = DatabaseLookup<float>("id_data");

            Console.WriteLine($"{sumEven}, ({sumVectors.X}, {sumVectors.Y}, {sumVectors.Z})");
            Console.ReadKey();
        }
    }
}

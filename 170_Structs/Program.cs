using System;

namespace _170_Structs
{
    class Vector3Class
    {
        public float X, Y, Z;

        public void Print()
        {
            Console.WriteLine($"({X}, {Y}, {Z})");
        }
    }

    struct Vector3Struct
    {
        public float X, Y, Z;

        public void Print()
        {
            Console.WriteLine($"({X}, {Y}, {Z})");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Vector3Class v1 = new Vector3Class()
            {
                X = 10,
                Y = -2,
                Z = 1.4f
            };

            Vector3Struct v2 = new Vector3Struct()
            {
                X = 58,
                Y = 12,
                Z = -2.4f
            };

            v1.Print();
            v2.Print();

            ChangeVectorClass(v1);
            ChangeVectorStruct(v2);

            v1.Print();//mudado
            v2.Print();//nao tenha mudado

            Console.ReadKey();
        }

        static void ChangeVectorClass(Vector3Class v)
        {
            v.X = v.Y = v.Z = 2;
        }

        static void ChangeVectorStruct(Vector3Struct v)
        {
            v.X = v.Y = v.Z = 2;
        }
    }
}

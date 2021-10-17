using System;

namespace _171_RefOutIn
{
    //===== Exemplo Ref 1 =====//

    // class Program
    // {
    //     static void Main(string[] args)
    //     {
    //         int[] numbers = new int[]
    //         {
    //             -1, 5, 10, 34, -87
    //         };

    //         Console.WriteLine(string.Join(", ", numbers));
    //         Swap(ref numbers[0], ref numbers[3]);
    //         Console.WriteLine(string.Join(", ", numbers));

    //         Console.ReadKey();
    //     }

    //     //Algoritimos de Sorting (ordenacao)    
    //     static void Swap(ref int a, ref int b)
    //     {
    //         int temp = a;
    //         a = b;
    //         b = temp;
    //     }

    //     static void Swap(int[] array, int i, int j)
    //     {
    //         int temp = array[i];
    //         array[i] = array[j];
    //         array[j] = temp;
    //     }
    // }

    //===== Exemplo Ref 2 =====//

    // class Program
    // {
    //     static void Main(string[] args)
    //     {
    //         string t = "My String";//char* t
    //         Console.WriteLine(t);
    //         ChangeString(ref t);
    //         Console.WriteLine(t);

    //         Console.ReadKey();
    //     }

    //     static void ChangeString(ref string text)//char** text
    //     {
    //         /*
    //         *text = (char*) malloc(10*sizeof(char));
    //         text[0] = 'N';
    //         text[1] = 'O';
    //         */
    //         text = "NO CHANGE";
    //     }
    // }

    //===== Exemplo Out =====//

    //"retornar" multiplos valores em uma funcao
    // static void Main(string[] args)
    // {
    //     string input = Console.ReadLine();
    //     if (int.TryParse(input, out int number))
    //     {
    //         Console.WriteLine($"Parse funcionou! - {number}");
    //     }
    //     else
    //     {
    //         Console.WriteLine($"Parse nao funcionou! {input}");
    //     }
    //     Console.ReadKey();

    //     int[] numbers =
    //     {
    //             1,2, -19
    //         };
    //     if (SafeGet(numbers, 1, out int value))
    //     {
    //         Console.WriteLine(value);
    //     }
    //     else
    //     {
    //         Console.WriteLine("Indice invalido!");
    //     }

    //     Console.ReadKey();
    // }

    // static bool SafeGet(int[] array, int index, out int value)
    // {
    //     if (index >= 0 && index < array.Length)
    //     {
    //         value = array[index];
    //         return true;
    //     }

    //     value = -1;
    //     return false;
    // }

    //===== Exemplo Int =====//
    // class Program
    // {
    //     /*
    //     -> A gente quer passar uma struct grande como referencia imutavel
    //         frequente
    //     */
    //     struct Vector3
    //     {
    //         public float X, Y, Z;//12
    //     }
    //     struct Transform//12*3 = 36 bytes, pointers -> 8 bytes
    //     {
    //         public Vector3 Position;
    //         public Vector3 Rotation;
    //         public Vector3 Scale;
    //     }

    //     static void Main(string[] args)
    //     {
    //         Transform t = new Transform
    //         {
    //             Position = new Vector3 { X = 0, Y = 0, Z = 0 },
    //             Rotation = new Vector3 { X = 0, Y = 0, Z = 0 },
    //             Scale = new Vector3 { X = 1, Y = 1, Z = 1 },
    //         };
    //     }

    //     static Vector3 GetForwardDirection(in Transform transform)
    //     {
    //         //rotation * (0,0,1)
    //         return new Vector3 { X = 0, Y = 0, Z = 1 };
    //     }
    // }
}

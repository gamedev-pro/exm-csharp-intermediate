using System;

namespace _169_ValueTypeRefType
{
    //===== Exemplo 1: Numeros ======//
    class Program
    {
        static void Main(string[] args)
        {
            int x = 10;
            Console.WriteLine(x);
            SumTwo(x);
            Console.WriteLine(x);
        }

        static void SumTwo(int x)
        {
            x = x + 2;
        }
    }


    //===== Exemplo 2: Classe ======//
    // class Item
    // {
    //     public int Price;
    //     public string Name;
    // }

    // class Program
    // {
    //     static void Main(string[] args)
    //     {
    //         Item item = new Item()
    //         {
    //             Price = 10,
    //             Name = "Test Item"
    //         };
    //         Console.WriteLine($"Item: {item.Name} - {item.Price}");
    //         ChangeItem(item);
    //         Console.WriteLine($"Item: {item.Name} - {item.Price}");
    //     }

    //     static void ChangeItem(Item item)
    //     {
    //         item.Price = 2;
    //         item.Name = "Other Name";
    //     }
    // }


    //===== Exemplo 3: Arrays ======//

    // class Program
    // {
    //     static void Main(string[] args)
    //     {
    //         int[] numbers = new int[3]
    //         {
    //             2, -11, 45
    //         };

    //         Console.WriteLine(numbers[1]);
    //         SumTwo(numbers[1]);
    //         Console.WriteLine(numbers[1]);

    //         SumTwo(numbers, 1);
    //         Console.WriteLine(numbers[1]);

    //         Console.ReadKey();
    //     }

    //     static void SumTwo(int number)
    //     {
    //         number = number + 2;
    //     }

    //     static void SumTwo(int[] numbers, int index)
    //     {
    //         numbers[index] = numbers[index] + 2;
    //     }
    // }

    //===== Exemplo 4: Arrays ======//
    // class Program
    // {
    //     static void Main(string[] args)
    //     {
    //         string myText = "My text";
    //         Console.WriteLine(myText);
    //         ChangeString(myText);
    //         Console.WriteLine(myText);
    //         Console.ReadKey();
    //     }

    //     //char* text
    //     static void ChangeString(string text)
    //     {
    //         char firstChar = text[0];
    //         Console.WriteLine(firstChar);
    //         text[0] = 'N';
    //     }
    // }
}

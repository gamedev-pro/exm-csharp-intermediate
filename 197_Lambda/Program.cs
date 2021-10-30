using System;

namespace _197_Lambda
{
    //Evento -> array de ponteiro para funcoes.
    //A.MyEvent.Invoke() <- B, C, D, E

    //Uma funcao como parametro de outra funcao?
    // Callbacks, Strategy, Processamento de Colecoes (LINQ) 

    class Program
    {
        //Action -> nao retonra nenhum valor
        //Func -> sempre retorna valor

        static int SumWhere(int[] numbers, Func<int, bool> filter)
        {
            int sum = 0;
            foreach (int number in numbers)
            {
                if (filter(number))//filtro
                {
                    sum += number;
                }
            }
            return sum;
        }

        static void Main(string[] args)
        {
            int[] numbers = new int[]
            {
                1, 2, 3, -4, 100, 485
            };


            Func<int, bool> isEven = (n) =>
            {
                return n % 2 == 0;
            };

            //Local function
            bool IsEven(int n)
            {
                //ddfasfjka
                return n % 2 == 0;
            }

            bool IsEven2(int n) => n % 2 == 0;

            int sumEven = SumWhere(numbers, IsEven2);


            int sumOdd = SumWhere(numbers, (n) =>
            {
                return n % 2 != 0;
            });

            int sumNegative = SumWhere(numbers, n => n < 0);

            Console.WriteLine($"{sumEven}, {sumOdd}, {sumNegative}");
            Console.ReadKey();
        }
    }
}
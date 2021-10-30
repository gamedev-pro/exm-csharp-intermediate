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

        //Filtro
        static bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        static bool IsOdd(int number)
        {
            return number % 2 != 0;
        }

        static bool IsNegative(int number)
        {
            return number < 0;
        }

        static void Main(string[] args)
        {
            int[] numbers = new int[]
            {
                1, 2, 3, -4, 100, 485
            };

            //Soma dos numeros que sao par
            //Operacao, apenas em numeros especificos
            //-> Filtra, Executa a operacao
            int sumEven = SumWhere(numbers, IsEven);

            Console.WriteLine($"Soma dos pares: {sumEven}");

            int sumOdd = SumWhere(numbers, IsOdd);

            Console.WriteLine($"Soma dos Impares: {sumOdd}");

            int sumNegative = SumWhere(numbers, IsNegative);

            Console.WriteLine($"Soma dos negativos: {sumNegative}");

            Console.ReadKey();
        }
    }
}
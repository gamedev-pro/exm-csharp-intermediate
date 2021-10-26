using System;
using System.Collections.Generic;

namespace _51_Desafio_Classes_2
{
    public class Store
    {
        private List<Item> items;

        public Store()
        {
            items = new List<Item>()
            {
                new Item("Pao de Queijo",1),
                new Item("Acaraje",3),
                new Item("Feijoada",3),
                new ConsumableItem("Health Potion", 10, 2),
                new Weapon("Axe", 7, 2),
                new Shield("Wood Shield", 4, 1)
            };
        }

        public void PrintGreetings()
        {
            PrintLineAndWait("Bem vindo a nossa loja!");
            PrintLineAndWait("Eu vejo que voce tem muitos coins com voce...");
            PrintLineAndWait("Hmmm... voce quer dar uma olhada no nosso inventario? Sim ou sim? :)");
        }

        public void ExecuteStoreLoop(Player player)
        {
            //enquanto o jogador tiver dinheiro E enquanto ele puder comprar alguma coisa
            while (player.CanBuyAny(items))
            {
                PrintStoreOptions();
                Item item = ReadItem("Digite o numero do Item que voce quer comprar -> ");
                if (player.TryPurchaseItem(item))
                {
                    Console.WriteLine();
                    PrintLineAndWait($"Voce comprou um {item.Name} por ${item.Price}! Voce tem ${player.Money} coins.");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine();
                    PrintLineAndWait($"Esse item custa ${item.Price} mas voce so tem ${player.Money}");
                    Console.WriteLine();
                }
            }
        }

        public void PrintEnding(Player player)
        {
            Console.WriteLine();
            Console.WriteLine("Voce nao consegue comprar mais nada! Esses sao seus items: ");
            player.PrintPlayerItems();

            Console.WriteLine();
            Console.ReadKey();
            PrintLineAndWait("...");
            PrintLineAndWait("Eh uma pena que esses items sao apenas bits no seu computador... (._.)");
        }

        private void PrintLineAndWait(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey();
        }

        private int ReadNumber(string message)
        {
            Console.Write(message);
            string input = Console.ReadLine();
            int number;
            if (int.TryParse(input, out number))
            {
                return number;
            }
            return -1;
        }

        private Item ReadItem(string message)
        {
            int index = ReadNumber(message);
            index -= 1;
            while (index < 0 || index >= items.Count)
            {
                Console.WriteLine("Eu nao conheco esse item. E voce nao sai daqui ate comprar!");
                index = ReadNumber(message);
                index -= 1;
            }
            return items[index];
        }

        private void PrintStoreOptions()
        {
            Console.WriteLine();
            Console.WriteLine("Essas sao as nossas opcoes:");
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {items[i].Name} - ${items[i].Price}");
            }
        }
    }
}

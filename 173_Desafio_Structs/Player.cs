using System;
using System.Collections.Generic;

namespace _172_Desafio_Structs
{
    public struct Player
    {
        public int Money;
        public List<Item> Inventory;

        public Player(int money)
        {
            Money = money;
            Inventory = new List<Item>();
        }

        public bool CanBuyAny(List<Item> items)
        {
            foreach (var item in items)
            {
                if (CanBuy(item))
                {
                    return true;
                }
            }
            return false;
        }

        public bool TryPurchaseItem(in Item item)
        {
            if (CanBuy(item))
            {
                Inventory.Add(item);
                Money -= item.Price;
                return true;
            }
            return false;
        }

        public void PrintPlayerItems()
        {
            foreach (var item in Inventory)
            {
                Console.WriteLine($"- {item.Name}");
            }
        }

        private bool CanBuy(in Item item)
        {
            return Money >= item.Price;
        }
    }
}

using System;
using System.Collections.Generic;

namespace _51_Desafio_Classes_2
{
    public class Player
    {
        public int Money { get; private set; }
        public List<Item> Inventory { get; private set; }

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

        public bool TryPurchaseItem(Item item)
        {
            if (CanBuy(item))
            {
                Inventory.Add(item);
                Money -= item.Price;

                TryUseItem(Inventory.Count - 1);
                TryEquipWeapon(Inventory.Count - 1);
                return true;
            }
            return false;
        }

        public void TryUseItem(int itemIndex)
        {
            if (itemIndex >= 0 && itemIndex < Inventory.Count)
            {
                if (Inventory[itemIndex] is ConsumableItem consumable)
                {
                    consumable.Use();
                }
            }
        }

        public void TryEquipWeapon(int itemIndex)
        {
            if (itemIndex >= 0 && itemIndex < Inventory.Count)
            {
                if (Inventory[itemIndex] is EquipableItem equipable)
                {
                    equipable.Equip();
                }
            }
        }

        public void PrintPlayerItems()
        {
            foreach (var item in Inventory)
            {
                Console.WriteLine($"- {item.Name}");
            }
        }

        private bool CanBuy(Item item)
        {
            return Money >= item.Price;
        }
    }
}

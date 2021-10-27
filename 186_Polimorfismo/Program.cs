using System;

namespace _186_Polimorfismo
{
    class Program
    {
        //Heranca
        public class Item
        {
            public string Name;
            public int Price;
        }

        public class ConsumableItem : Item
        {
            private bool wasUsed;

            public virtual void Use()
            {
                if (!wasUsed)
                {
                    Console.WriteLine("Ok, vou ser usado");
                    wasUsed = true;
                }
                else
                {
                    Console.WriteLine("NAO POSSO SER USADO");
                }
            }
        }

        public class HealthPotion : ConsumableItem
        {
            private int Amount;
            public override void Use()
            {
                base.Use();
                Console.WriteLine("Health Potion sendo usada!");
            }
        }

        public class MagicBoost : ConsumableItem
        {
            public override void Use()
            {
                base.Use();
                Console.WriteLine("Magic Boost sendo usado!");
            }
        }

        public class ManaPotion : ConsumableItem
        {
            public override void Use()
            {
                base.Use();
                Console.WriteLine("Mana Potion sendo usada!");
            }
        }
        static void Main(string[] args)
        {
            foreach (ConsumableItem item in GetConsumables())
            {
                item.Use();
                item.Use();
            }

            ConsumableItem hp = new HealthPotion();
            hp.Use();
            Console.ReadKey();
        }

        static ConsumableItem[] GetConsumables()
        {
            return new ConsumableItem[]
            {
                new HealthPotion(),
                new MagicBoost(),
                new ManaPotion()
            };
        }
    }
}

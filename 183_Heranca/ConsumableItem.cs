using System;

namespace _51_Desafio_Classes_2
{
    public class ConsumableItem : Item
    {
        public int MaxUses { get; private set; }
        private int currentUseCount;

        public ConsumableItem(string name, int price, int maxUses) : base(name, price)
        {
            MaxUses = maxUses;
        }

        public void Use()
        {
            if (currentUseCount <= MaxUses)
            {
                Console.WriteLine("Estou sendo consumido!");
                currentUseCount++;
            }
            else
            {
                Console.WriteLine("Item consumido");
            }
        }
    }
}
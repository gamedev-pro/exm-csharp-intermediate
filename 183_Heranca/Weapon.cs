using System;

namespace _51_Desafio_Classes_2
{
    public class EquipableItem : Item
    {
        public EquipableItem(string name, int price) : base(name, price)
        { }

        public bool IsEquipped { get; private set; }

        public void Equip()
        {
            IsEquipped = true;
            Console.WriteLine($"Equipando item {Name}");
        }

        public void Unequip()
        {
            IsEquipped = false;
        }
    }

    public class Weapon : EquipableItem
    {
        public int AttackPower { get; private set; }
        public Weapon(string name, int price, int attackPower) : base(name, price)
        {
            AttackPower = attackPower;
        }
    }

    public class Shield : EquipableItem
    {
        public int Defense { get; private set; }
        public Shield(string name, int price, int defense) : base(name, price)
        {
            Defense = defense;
        }
    }
}
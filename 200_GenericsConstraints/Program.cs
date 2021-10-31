using System;
using System.Collections.Generic;

namespace _200_GenericsConstraints
{
    class Program
    {
        static void SetElementsToNull<T>(T[] elements) where T : class
        {
            for (int i = 0; i < elements.Length; i++)
            {
                elements[i] = null;//"Destruir" o objeto
            }
        }

        static void FillList<T>(List<T> elements, int numberOfElementsToCreate) where T : new()
        {
            elements.Clear();
            for (int i = 0; i < numberOfElementsToCreate; i++)
            {
                T element = new T();
                elements.Add(element);
            }
        }

        public class Weapon
        {
            public Weapon(int damage, int rarity)
            {

            }
        }

        static void Main(string[] args)
        {
            string[] names = new string[] { "name1", "name2" };
            SetElementsToNull(names);

            List<Weapon> weapons = new List<Weapon>();
            FillList(weapons, 10);

            Console.WriteLine("Hello World!");
        }
    }
}

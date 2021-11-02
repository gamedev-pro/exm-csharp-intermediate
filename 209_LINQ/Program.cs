using System;
using System.Collections.Generic;
using System.Linq;

namespace _209_LINQ
{
    public static class LinqUtils
    {
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var item in collection)
            {
                action(item);
            }
        }
    }

    class Program
    {
        public enum ItemRarity
        {
            Common, Rare, Epic, Legendary
        }

        public class Item
        {
            public int Price;
            public string Name;

            public ItemRarity Rarity;

            public Item(string name, int price, ItemRarity rarity)
            {
                Name = name;
                Price = price;
                Rarity = rarity;
            }
        }

        public class Store
        {
            public List<Item> Items;
        }

        static void Main(string[] args)
        {
            var store = new Store()
            {
                Items = new List<Item>()
                {
                    new Item("Item 1", 10, ItemRarity.Common),
                    new Item("Item 2", 20, ItemRarity.Legendary),
                    new Item("Item 3", 15, ItemRarity.Legendary),
                }
            };

            var sumPrices = store.Items.Sum(item => item.Price);
            var avgPrices = store.Items.Average(item => item.Price);

            var legendaryItems = store.Items.Where(item => item.Rarity == ItemRarity.Legendary);

            //versao "sql"
            var legendaryItems2 = from item in store.Items
                                  where item.Rarity == ItemRarity.Legendary
                                  select item;

            foreach (var legendaryItem in legendaryItems)
            {
                Console.WriteLine($"Legendary Item: {legendaryItem.Name} - {legendaryItem.Price}");
            }
            Console.WriteLine($"Total Legendary Item Price: {legendaryItems.Sum(item => item.Price)}");

            store.Items
                .OrderBy(item => item.Price)
                .ForEach(item => Console.WriteLine($"{item.Name} - {item.Price}"));

            Console.ReadKey();
        }
    }
}

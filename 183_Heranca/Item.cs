namespace _51_Desafio_Classes_2
{
    public class Item
    {
        public string Name { get; private set; }
        public int Price { get; private set; }

        public Item(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }
}

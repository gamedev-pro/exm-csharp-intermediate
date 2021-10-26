namespace _51_Desafio_Classes_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player(5);
            var store = new Store();

            store.PrintGreetings();

            store.ExecuteStoreLoop(player);

            store.PrintEnding(player);
        }
    }
}

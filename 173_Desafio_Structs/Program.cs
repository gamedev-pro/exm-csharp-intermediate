namespace _172_Desafio_Structs
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player(5);
            var store = new Store();

            store.PrintGreetings();

            store.ExecuteStoreLoop(ref player);

            store.PrintEnding(player);
        }
    }
}

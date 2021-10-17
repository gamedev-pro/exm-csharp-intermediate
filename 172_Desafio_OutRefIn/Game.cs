using System;

namespace _172_Desafio_OutRefIn
{
    class Game
    {
        private Player player;
        private ConsoleEngine engine;
        public Game()
        {
            player = new Player()
            {
                Position = new Vector2
                {
                    X = 10,
                    Y = 10
                },
                RectSize = new Vector2
                {
                    X = 2,
                    Y = 1,
                }
            };
            engine = new ConsoleEngine(player);
        }

        public void Play()
        {
            while (true)
            {
                engine.Draw();
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }

                if (key.Key == ConsoleKey.D)
                {
                    player.Position.X += 5;
                }

                if (key.Key == ConsoleKey.A)
                {
                    player.Position.X -= 5;
                }

                if (key.Key == ConsoleKey.W)
                {
                    player.Position.Y -= 5;
                }

                if (key.Key == ConsoleKey.S)
                {
                    player.Position.Y += 5;
                }
            }
        }
    }
}

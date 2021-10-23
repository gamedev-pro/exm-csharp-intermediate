using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _178_FileReadWrite
{
    public class GameData
    {
        public int Number;
        public string Text;
    }

    class Program
    {
        static void Main(string[] args)
        {
            var data = new GameData
            {
                Number = 20,
                Text = "Afddfsdfsds"
            };
            var gameDataPath = $"{Directory.GetCurrentDirectory()}/save.txt";

            SaveGame(data, gameDataPath);

            var loadedData = LoadGame(gameDataPath);
            Console.WriteLine($"Number {loadedData.Number}, Text: {loadedData.Text}");
            Console.ReadKey();
        }

        private static void SaveGame(GameData data, string gameDataPath)
        {
            using (FileStream stream = new FileStream(gameDataPath, FileMode.Create, FileAccess.Write))
            using (StreamWriter writer = new StreamWriter(stream))
            {
                writer.WriteLine($"{data.Number}");
                writer.WriteLine($"{data.Text}");
            }
        }

        private static GameData LoadGame(string gameDatapath)
        {
            GameData gameData = new GameData();
            using (FileStream stream = new FileStream(gameDatapath, FileMode.Open, FileAccess.Read))
            using (StreamReader reader = new StreamReader(stream))
            {
                string numberLine = reader.ReadLine();
                if (!string.IsNullOrEmpty(numberLine))
                {
                    gameData.Number = int.Parse(numberLine);
                }

                string textLine = reader.ReadLine();
                if (!string.IsNullOrEmpty(textLine))
                {
                    gameData.Text = textLine;
                }
            }

            return gameData;
        }
    }
}

using System;

namespace _191_Classes_Abstratas
{
    class Program
    {
        //Achievements 
        //1 - Eles tem comportamentos bem diferentes (Polimorficos)
        //2 - Eles tem funcionalidade em comum
        //    - Nao pode ser completado duas vezes
        //    - As recompensas

        public class Player
        {
            public int HeadShotCount;
        }

        public abstract class Achievement
        {
            public string Name { get; private set; }
            public bool IsComplete { get; private set; }

            public Achievement(string name)
            {
                Name = name;
            }

            public void TryComplete(Player player)
            {
                if (!IsComplete && CanBeCompleted(player))
                {
                    IsComplete = true;
                    GiveRewards();
                }
                else
                {
                    Console.WriteLine($"{Name} - Achievement nao foi completado!");
                }
            }

            protected virtual void GiveRewards()
            {
                Console.WriteLine($"{Name} - Dando rewards pro player!");
            }

            //eh acessivel para FILHOS dessa classe
            protected abstract bool CanBeCompleted(Player player);
        }

        public class HeadShotAchievement : Achievement
        {
            private int requiredHeadShotCount;
            public HeadShotAchievement(string name, int requiredHeadShotCount) : base(name)
            {
                this.requiredHeadShotCount = requiredHeadShotCount;
            }

            protected override bool CanBeCompleted(Player player)
            {
                return player.HeadShotCount >= requiredHeadShotCount;
            }
        }

        public class PurchaseWeapon : Achievement
        {
            public PurchaseWeapon(string name) : base(name)
            {
            }

            protected override bool CanBeCompleted(Player player)
            {
                //TODO: Check if player has weapon
                return false;
            }
        }

        static void Main(string[] args)
        {
            Player player = new Player();
            foreach (Achievement achievement in achievements)
            {
                achievement.TryComplete(player);
            }

            Console.ReadKey();
        }

        static Achievement[] achievements = new Achievement[]
        {
            new HeadShotAchievement("First Head Shot", 1),
            new HeadShotAchievement("Sniper Disciple", 10),
            new PurchaseWeapon("Purchase Sniper Rifle")
        };
    }
}

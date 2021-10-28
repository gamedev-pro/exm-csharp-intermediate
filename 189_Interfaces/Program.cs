using System;
using System.Collections.Generic;

namespace _189_Interfaces
{
    class Program
    {
        public interface IDamageable //que eh capaz de tomar dano
        {
            int Health { get; }
            int MaxHealth { get; }

            void TakeDamage(int damage);
        }

        public interface IHealable
        {
            void Heal(int amount);
        }

        public interface IQuestGiver
        {
            void GiveQuest();
        }

        public class ExplosiveObject : IDamageable
        {
            public int Health { get; private set; }

            public int MaxHealth { get; private set; }

            public ExplosiveObject(int maxHealth)
            {
                Health = MaxHealth = maxHealth;
            }

            public void TakeDamage(int damage)
            {
                Health = Math.Max(0, Health - damage);
                Console.WriteLine($"Tomei dano {damage}. Health - {Health}");
                if (Health == 0)
                {
                    //TODO: Explosao!
                    Console.WriteLine("Explosao!!!");
                }
            }
        }

        public class NPC : IDamageable, IHealable, IQuestGiver
        {
            public string Name { get; private set; }
            public int Health { get; private set; }

            public int MaxHealth { get; private set; }

            public NPC(int maxHealth, string name)
            {
                Health = MaxHealth = maxHealth;
                Name = name;
            }

            public void TakeDamage(int damage)
            {
                Health = Math.Max(0, Health - damage);
                Console.WriteLine($"Tomei dano {damage}. Health - {Health}");
                if (Health == 0)
                {
                    //TODO: Tocar animacao de morte, checar se a quest falhou
                    Console.WriteLine($"NPC morreu! - {Name}");
                }
            }

            public void Heal(int amount)
            {
                if (Health > 0)
                {
                    Health = Math.Min(MaxHealth, Health + amount);
                    Console.WriteLine($"{Name}: Recuperei vida {amount}. Health = {Health}");
                }
                else
                {
                    Console.WriteLine($"{Name}: Estou morto, nao posso recuperar vida");
                }
            }

            public void GiveQuest()
            {
                throw new NotImplementedException();
            }
        }

        static void Main(string[] args)
        {
            foreach (IDamageable damageable in damageables)
            {
                damageable.TakeDamage(2);
            }

            Console.WriteLine();
            Console.WriteLine();

            foreach (IHealable healable in GetHealables())
            {
                healable.Heal(100);
            }

            Console.ReadKey();
        }

        private static IHealable[] GetHealables()
        {
            List<IHealable> healables = new List<IHealable>();
            foreach (IDamageable damageable in damageables)
            {
                if (damageable is IHealable healable)
                {
                    healables.Add(healable);
                }
            }
            return healables.ToArray();
        }

        private static IDamageable[] damageables = new IDamageable[]
        {
            new ExplosiveObject(1),
            new ExplosiveObject(2),
            new ExplosiveObject(20),
            new NPC(2, "NPC 1"),
            new NPC(5, "NPC 2")
        };
    }
}

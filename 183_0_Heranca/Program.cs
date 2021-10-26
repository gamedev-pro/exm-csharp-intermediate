using System;

namespace _183_0_Heranca
{
    class Program
    {
        public class Sword
        {
            public int AttackPower { get; set; }
            public int Durability { get; set; }
            public void Attack()
            {
                Console.WriteLine($"Im Attacking! {AttackPower}");
            }
        }

        //MagicSword herda da classe Sword (uma especializacao, ou uma filha)
        public class MagicSword : Sword
        {
            public float MagicBoost;
            public int ManaCost;
        }
        static void Main(string[] args)
        {
            Sword sword = new Sword()
            {
                AttackPower = 10,
                Durability = 100
            };

            sword.Attack();

            Sword magicSword = new MagicSword() //MagicSword É UMA Sword
            {
                AttackPower = 20,
                Durability = 30,
                MagicBoost = 1.2f,
                ManaCost = 1
            };

            magicSword.Attack();

            //Cast: Converter de uma classe pai para a filha
            //Converter de uma classe MENOS especializada para uma MAIS especializada
            //Cast eh uma re-interpretacao de tipo (ele nao muda os dados)
            MagicSword magicSword2 = magicSword as MagicSword;//null se o tipo nao for o que voce espera
            if (magicSword2 == null)
            {
                Console.WriteLine("Tipo inesperado no cast!");
            }
            else
            {
                magicSword2.Attack();
            }

            Console.ReadKey();
        }
    }
}

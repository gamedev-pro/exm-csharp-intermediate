using System;

namespace _195_Eventos
{
    public abstract class Component
    {
        public void Destroy()
        {
            OnDestroy();
        }

        protected abstract void OnDestroy();
    }

    public struct LevelUpEventArgs
    {
        public Player Player;
        public int PreviousLevel;
    }

    //Action, Func
    // Action -> delegate que sempre retorna void (mas recebe qualquer coisa)
    // Func -> delegate que sempre retorna alguma coisa e pode receber o que voce quiser (inclusive nada)
    public class Player
    {
        //Exemplo de drawback com Action (nao tem nome de parametros)
        delegate void LevelUPEventDelegate(Player player, int previousLevel, int level);
        public event Action<Player, int, int> LevelUpEvent2;
        //

        public event Action<LevelUpEventArgs> LevelUpEvent;

        //delegate LevelUpEventArgs MyDelegate();
        public event Func<LevelUpEventArgs, bool> LevelUpEventFunc;
        public int Level { get; private set; }

        public void GainXP()
        {
            Level++;
            LevelUpEvent?.Invoke(new LevelUpEventArgs()
            {
                Player = this,
                PreviousLevel = Level - 1
            });

            FilterBy(new int[] { 1, 2, 3 }, TestFilter);
        }

        private bool TestFilter(int number)
        {
            return false;
        }

        private void FilterBy(int[] array, Func<int, bool> filter)
        {
            foreach (int number in array)
            {
                bool passedFilter = filter(number);
            }
        }
    }

    public class AchievementsTracker : Component
    {
        private Player player;
        public AchievementsTracker(Player player)
        {
            this.player = player;
            this.player.LevelUpEvent += OnPlayerLevelUp;//Inscreve uma Funcao em um Delegate
        }

        protected override void OnDestroy()
        {
            this.player.LevelUpEvent -= OnPlayerLevelUp;//Desinscrevendo do evento
        }

        private void OnPlayerLevelUp(LevelUpEventArgs args)
        {
            Console.WriteLine($"Achievements Response (Player Level Up): {args.Player.Level}");
        }

    }

    public class NotificationsService : Component
    {
        private Player player;
        public NotificationsService(Player player)
        {
            this.player = player;
            this.player.LevelUpEvent += OnPlayerLevelUp;
        }

        protected override void OnDestroy()
        {
            this.player.LevelUpEvent -= OnPlayerLevelUp;//Desinscrevendo do evento
        }

        private void OnPlayerLevelUp(LevelUpEventArgs args)
        {
            Console.WriteLine($"NotificationsService Response (Player Level Up): {args.Player.Level}");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();

            AchievementsTracker achievementsTracker = new AchievementsTracker(player);
            NotificationsService notificationsService = new NotificationsService(player);

            player.GainXP();
            player.GainXP();

            achievementsTracker.Destroy();
            notificationsService.Destroy();

            player.GainXP();
            player.GainXP();
            player.GainXP();


            Console.ReadKey();
        }
    }
}

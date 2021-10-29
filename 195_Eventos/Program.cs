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

    public class Player
    {
        public event EventHandler<LevelUpEventArgs> LevelUpEvent;
        public int Level { get; private set; }

        public void GainXP()
        {
            Level++;
            LevelUpEvent?.Invoke(this, new LevelUpEventArgs()
            {
                Player = this,
                PreviousLevel = Level - 1
            });
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

        private void OnPlayerLevelUp(object sender, LevelUpEventArgs args)
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

        private void OnPlayerLevelUp(Player player)
        {
            Console.WriteLine($"NotificationsService Response (Player Level Up): {player.Level}");
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

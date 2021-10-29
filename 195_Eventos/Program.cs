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

    // delegate -> ponteiros para funcao (C# ele eh um objeto que guarda um ponteiro da funcao)
    public delegate void LevelUpEventDelegate(Player player);//Definindo um tipo

    public class Player
    {
        public event LevelUpEventDelegate LevelUpEvent;
        public int Level { get; private set; }

        public void GainXP()
        {
            Level++;
            LevelUpEvent?.Invoke(this);
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

        private void OnPlayerLevelUp(Player player)
        {
            Console.WriteLine($"Achievements Response (Player Level Up): {player.Level}");
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

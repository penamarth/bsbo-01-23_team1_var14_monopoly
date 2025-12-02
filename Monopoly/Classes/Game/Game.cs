using Monopoly.Classes.IO;
using Monopoly.Classes.Mementos;


namespace Monopoly.Classes.Game;

public class Game
{
    private List<Player> players = new List<Player>();

    public void StartGame()
    {
        Console.WriteLine("Игра вызывает StartGame и имитирует запуск");
        // Имитация добавления игроков
        if (players.Count == 0)
        {
            players.Add(new Player { Id = 1, Name = "Игрок1", Skin = "Скин1" });
            players.Add(new Player { Id = 2, Name = "Игрок2", Skin = "Скин2" });
        }
        // Имитация ходов (несколько для демонстрации)
        foreach (var player in players)
        {
            Console.WriteLine("Игра спрашивает действие игрока через IOS.Input");
            string action = IOS.Input();
            Console.WriteLine("Игра вызывает Player.Move");
            player.Move();
            Console.WriteLine("Игра спрашивает об опциональных действиях через IOS.Input");
            string optional = IOS.Input();
            if (optional == "yes")
            {
                Console.WriteLine("Игра вызывает Player.Sell (опциональное действие)");
                player.Sell();
            }
        }
    }

    public void StopGame()
    {
        Console.WriteLine("Игра вызывает StopGame и имитирует остановку");
    }

    public GameMemento CreateMemento()
    {
        Console.WriteLine("Игра создает Memento");
        List<PlayerMemento> playerMems = new List<PlayerMemento>();
        foreach (var p in players)
        {
            playerMems.Add(p.CreateMemento());
        }
        return new GameMemento(playerMems, PropertyRegistry.CreateMemento());
    }

    public void Restore(GameMemento memento)
    {
        Console.WriteLine("Игра восстанавливается из Memento");
        players = new List<Player>();
        foreach (var pm in memento.PlayerMementos)
        {
            var p = new Player();
            p.Restore(pm);
            players.Add(p);
        }
        PropertyRegistry.Restore(memento.PropertyRegistryMemento);
    }
}



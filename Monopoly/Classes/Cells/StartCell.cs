using Monopoly.Classes.Game;
using Monopoly.Interfaces;

namespace Monopoly.Classes.Cells;

public class StartCell : ICell
{
    public string GetInfo()
    {
        Console.WriteLine("КлеткаСтарта возвращает информацию о себе");
        return "Стартовая клетка";
    }

    public void Handle(int playerId)
    {
        Console.WriteLine($"КлеткаСтарта обрабатывает игрока {playerId} и вызывает increaseMoney");
        increaseMoney(playerId);
    }

    private void increaseMoney(int playerId)
    {
        Console.WriteLine($"КлеткаСтарта вызывает Bank.IncreaseBalance для игрока {playerId}");
        Bank.IncreaseBalance(200, playerId); // Имитация награды
    }
}
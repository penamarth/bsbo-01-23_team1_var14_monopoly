using Monopoly.Classes.Game;
using Monopoly.Interfaces;

namespace Monopoly.Classes.Cells;

public class ChanceCell : ICell
{
    public string GetInfo()
    {
        Console.WriteLine("КлеткаШанс возвращает информацию о себе");
        return "Клетка шанса";
    }

    public void Handle(int playerId)
    {
        Console.WriteLine($"КлеткаШанс обрабатывает игрока {playerId} и имитирует шанс (increase/decrease)");
        if (new Random().Next(2) == 0)
        {
            Bank.IncreaseBalance(100, playerId);
        }
        else
        {
            Bank.DecreaseBalance(100, playerId);
        }
    }
}
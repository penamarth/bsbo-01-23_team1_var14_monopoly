using Monopoly.Interfaces;

namespace Monopoly.Classes.Cells;

public class JailCell : ICell
{
    public string GetInfo()
    {
        Console.WriteLine("КлеткаТюрьма возвращает информацию о себе");
        return "Тюрьма";
    }

    public void Handle(int playerId)
    {
        Console.WriteLine($"КлеткаТюрьма обрабатывает игрока {playerId} (имитация, без действий)");
    }
}
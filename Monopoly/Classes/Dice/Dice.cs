using Monopoly.Interfaces;

namespace Monopoly.Classes.Dice;

public class Dice : IDice
{
    public int Roll()
    {
        Console.WriteLine("Кубик имитирует бросок (случайное число от 1 до 6)");
        return new Random().Next(1, 7);
    }
}
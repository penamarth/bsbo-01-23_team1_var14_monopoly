namespace Monopoly.Classes.Dice;

public static class DiceCup
{
    private static List<Dice> dice = new List<Dice> { new Dice(), new Dice() }; // Стандартно 2 кубика

    public static int Roll()
    {
        Console.WriteLine("Стакан вызывает Roll у каждого кубика и суммирует");
        int sum = 0;
        foreach (var d in dice)
        {
            sum += d.Roll();
        }
        return sum;
    }
}
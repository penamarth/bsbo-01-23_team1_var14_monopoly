using Monopoly.Interfaces;

namespace Monopoly.Classes.IO;

public class IOS
{
    public static IIO IO { get; set; }

    public static string Input()
    {
        Console.WriteLine("IOS вызывает метод Input у реализации IIO");
        return IO.Input();
    }

    public static void Output(string message)
    {
        Console.WriteLine($"IOS вызывает метод Output у реализации IIO с сообщением: {message}");
        IO.Output(message);
    }
}
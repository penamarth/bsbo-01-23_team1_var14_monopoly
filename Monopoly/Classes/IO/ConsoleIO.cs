using Monopoly.Interfaces;

namespace Monopoly.Classes.IO;

public class ConsoleIO : IIO
{
    public string Input()
    {
        Console.WriteLine("ConsoleIO имитирует чтение ввода от пользователя");
        return "yes"; // Имитация, всегда "yes" для демонстрации
    }

    public void Output(string message)
    {
        Console.WriteLine($"ConsoleIO выводит сообщение: {message}");
    }
}
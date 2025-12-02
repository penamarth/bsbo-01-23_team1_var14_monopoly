using Monopoly.Interfaces;

namespace Monopoly.Classes.IO;

public class GraphicalIO : IIO // Пример, как указано в диаграмме
{
    public string Input()
    {
        Console.WriteLine("GraphicalIO имитирует чтение ввода");
        return "yes";
    }

    public void Output(string message)
    {
        Console.WriteLine($"GraphicalIO имитирует вывод: {message}");
    }
}
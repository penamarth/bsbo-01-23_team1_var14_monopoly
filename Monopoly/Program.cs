using Monopoly.Classes.Game;
using Monopoly.Classes.IO;
using Monopoly.Classes.Mementos;


namespace Monopoly;

class Program
{
    static void Main(string[] args)
    {
        // Инициализация
        IOS.IO = new ConsoleIO();
        Game game = new Game();
        Caretaker caretaker = new Caretaker(game);

        // Имитация игры
        game.StartGame();

        // Сохранение состояния
        caretaker.MakeBackup();
        
        game.StopGame();
        
        // Восстановление
        caretaker.Undo();
        
        // Еще имитация (изменения)
        game.StartGame();

        
        // Сохранение/загрузка в файл (имитация)
        caretaker.SaveToFile("save.json");
        caretaker.LoadFromFile("save.json");

        game.StopGame();
    }
}
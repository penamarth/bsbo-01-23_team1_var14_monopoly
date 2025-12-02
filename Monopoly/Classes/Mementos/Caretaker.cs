using System.Text.Json;
using Monopoly.Classes.Game;

namespace Monopoly.Classes.Mementos;

public class Caretaker
{
    private Stack<GlobalState> history = new Stack<GlobalState>();
    private Game.Game game;

    public Caretaker(Game.Game game)
    {
        this.game = game;
    }

    public void MakeBackup()
    {
        Console.WriteLine("CareTaker вызывает MakeBackup: собирает Memento от Game, Bank, Board");
        GlobalState gs = new GlobalState(
            game.CreateMemento(),
            Bank.CreateMemento(),
            Board.CreateMemento()
        );
        history.Push(gs);
    }

    public void Undo()
    {
        if (history.Count == 0) return;
        Console.WriteLine("CareTaker вызывает Undo: восстанавливает Game, Bank, Board из Memento");
        GlobalState gs = history.Pop();
        game.Restore(gs.GameMemento);
        Bank.Restore(gs.BankMemento);
        Board.Restore(gs.BoardMemento);
        return;
    }

    public void SaveToFile(string path)
    {
        Console.WriteLine($"CareTaker сохраняет историю в файл {path} (JSON сериализация стека)");
        string json = JsonSerializer.Serialize(history);
        File.WriteAllText(path, json);
    }

    public void LoadFromFile(string path)
    {
        Console.WriteLine($"CareTaker загружает историю из файла {path} (JSON десериализация стека)");
        string json = File.ReadAllText(path);
        history = JsonSerializer.Deserialize<Stack<GlobalState>>(json);
    }
}
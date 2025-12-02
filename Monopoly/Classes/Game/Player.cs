using Monopoly.Classes.Mementos;

namespace Monopoly.Classes.Game;

public class Player
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Skin { get; set; }

    public void Move()
    {
        Console.WriteLine($"Игрок {Id} вызывает Board.Move с своим id");
        Board.Move(Id);
        // Имитация switch результата (не реализовано, как указано - только взаимодействия)
    }

    public void Sell()
    {
        Console.WriteLine($"Игрок {Id} вызывает PropertyRegistry.SellHouse");
        PropertyRegistry.SellHouse(Id);
    }

    public string GetBalance()
    {
        Console.WriteLine($"Игрок {Id} вызывает Bank.GetBalance");
        return Bank.GetBalance(Id).ToString();
    }

    public PlayerMemento CreateMemento()
    {
        Console.WriteLine($"Игрок {Id} создает Memento");
        return new PlayerMemento(Id, Name, Skin);
    }

    public void Restore(PlayerMemento memento)
    {
        Console.WriteLine($"Игрок восстанавливается из Memento");
        Id = memento.Id;
        Name = memento.Name;
        Skin = memento.Skin;
    }
}
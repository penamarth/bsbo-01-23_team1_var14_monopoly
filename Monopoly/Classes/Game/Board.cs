using Monopoly.Classes.Cells;
using Monopoly.Classes.Dice;
using Monopoly.Classes.Mementos;
using Monopoly.Interfaces;

namespace Monopoly.Classes.Game;

public static class Board
{
    private static Dictionary<int, int> playerPositions = new Dictionary<int, int>();
    private static List<ICell> cells = new List<ICell>();
    private static string features = "Особенности доски (имитация)";

    static Board()
    {
        // Имитация доски с клетками
        cells.Add(new StartCell());
        cells.Add(new PropertyCell(new Property { Cost = 100 }));
        cells.Add(new ChanceCell());
        cells.Add(new JailCell());
        cells.Add(new PropertyCell(new Property { Cost = 200 }));
    }

    public static ICell Move(int playerId)
    {
        Console.WriteLine($"Доска получает запрос на Move для игрока {playerId}");
        int rolls = DiceCup.Roll();
        Console.WriteLine($"Доска вызывает DiceCup.Roll и получает {rolls}");
        if (!playerPositions.ContainsKey(playerId)) playerPositions[playerId] = 0;
        int newPos = (playerPositions[playerId] + rolls) % cells.Count;
        playerPositions[playerId] = newPos;
        Console.WriteLine($"Доска обновляет позицию игрока {playerId} на {newPos}");
        ICell cell = cells[newPos];
        Console.WriteLine($"Доска вызывает {cell.GetType().Name}.Handle для игрока {playerId}");
        cell.Handle(playerId);
        return cell;
    }

    public static BoardMemento CreateMemento()
    {
        Console.WriteLine("Доска создает Memento");
        return new BoardMemento(new Dictionary<int, int>(playerPositions), new List<ICell>(cells), features);
    }

    public static void Restore(BoardMemento memento)
    {
        Console.WriteLine("Доска восстанавливается из Memento");
        playerPositions = new Dictionary<int, int>(memento.PlayerPositions);
        cells = new List<ICell>(memento.Cells);
        features = memento.Features;
    }
}
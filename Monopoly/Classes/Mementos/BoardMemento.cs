using Monopoly.Interfaces;

namespace Monopoly.Classes.Mementos;

public class BoardMemento
{
    public Dictionary<int, int> PlayerPositions { get; }
    public List<ICell> Cells { get; }
    public string Features { get; }

    public BoardMemento(Dictionary<int, int> playerPositions, List<ICell> cells, string features)
    {
        PlayerPositions = playerPositions;
        Cells = cells;
        Features = features;
    }
}
namespace Monopoly.Classes.Mementos;

public class GlobalState
{
    public GameMemento GameMemento { get; }
    public BankMemento BankMemento { get; }
    public BoardMemento BoardMemento { get; }

    public GlobalState(GameMemento gameMemento, BankMemento bankMemento, BoardMemento boardMemento)
    {
        GameMemento = gameMemento;
        BankMemento = bankMemento;
        BoardMemento = boardMemento;
    }
}
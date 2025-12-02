namespace Monopoly.Classes.Mementos;

public class BankMemento
{
    public int BankBalance { get; }
    public Dictionary<int, int> PlayerBalances { get; }

    public BankMemento(int bankBalance, Dictionary<int, int> playerBalances)
    {
        BankBalance = bankBalance;
        PlayerBalances = playerBalances;
    }
}
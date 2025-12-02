using Monopoly.Classes.Mementos;

namespace Monopoly.Classes.Game;

public static class Bank
{
    private static int bankBalance = 1000000;
    private static Dictionary<int, int> playerBalances = new Dictionary<int, int>();

    public static void IncreaseBalance(int amount, int playerId)
    {
        Console.WriteLine($"Банк увеличивает баланс игрока {playerId} на {amount}");
        if (!playerBalances.ContainsKey(playerId)) playerBalances[playerId] = 0;
        playerBalances[playerId] += amount;
        bankBalance -= amount;
    }

    public static void DecreaseBalance(int amount, int playerId)
    {
        Console.WriteLine($"Банк уменьшает баланс игрока {playerId} на {amount}");
        if (!playerBalances.ContainsKey(playerId)) playerBalances[playerId] = 0;
        if (playerBalances[playerId] >= amount)
        {
            playerBalances[playerId] -= amount;
            bankBalance += amount;
        }
    }

    public static int GetBalance(int playerId)
    {
        Console.WriteLine($"Банк возвращает баланс игрока {playerId}");
        return playerBalances.GetValueOrDefault(playerId, 0);
    }

    public static BankMemento CreateMemento()
    {
        Console.WriteLine("Банк создает Memento");
        return new BankMemento(bankBalance, new Dictionary<int, int>(playerBalances));
    }

    public static void Restore(BankMemento memento)
    {
        Console.WriteLine("Банк восстанавливается из Memento");
        bankBalance = memento.BankBalance;
        playerBalances = new Dictionary<int, int>(memento.PlayerBalances);
    }
}

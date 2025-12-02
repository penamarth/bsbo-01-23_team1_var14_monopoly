using Monopoly.Classes.Mementos;
using Monopoly.Interfaces;

namespace Monopoly.Classes.Game;

public static class PropertyRegistry
{
    private static Dictionary<int, List<IProperty>> playerProperties = new Dictionary<int, List<IProperty>>();
    private static Dictionary<IProperty, int> propertyOwners = new Dictionary<IProperty, int>();

    public static void BuyHouse(int playerId, IProperty property)
    {
        Console.WriteLine($"РеестрНедвижимости вызывает Bank.DecreaseBalance для покупки игроком {playerId}");
        int price = GetHousePrice(property);
        Bank.DecreaseBalance(price, playerId);
        if (!playerProperties.ContainsKey(playerId)) playerProperties[playerId] = new List<IProperty>();
        playerProperties[playerId].Add(property);
        propertyOwners[property] = playerId;
        Console.WriteLine($"РеестрНедвижимости добавляет недвижимость в маппинг для игрока {playerId}");
    }

    public static void SellHouse(int playerId)
    {
        Console.WriteLine($"РеестрНедвижимости имитирует продажу для игрока {playerId}");
        // Имитация, без реальной логики
    }

    public static List<IProperty> GetHouses(int playerId)
    {
        Console.WriteLine($"РеестрНедвижимости возвращает недвижимость для игрока {playerId}");
        return playerProperties.GetValueOrDefault(playerId, new List<IProperty>());
    }

    public static void PayRent(int playerId, IProperty property)
    {
        int rent = GetHousePrice(property) / 10; // Имитация аренды
        Console.WriteLine($"РеестрНедвижимости вызывает Bank.DecreaseBalance для оплаты аренды игроком {playerId}");
        Bank.DecreaseBalance(rent, playerId);
        int owner = GetHouseOwner(property);
        Console.WriteLine($"РеестрНедвижимости вызывает Bank.IncreaseBalance для владельца {owner}");
        Bank.IncreaseBalance(rent, owner);
    }

    public static int GetHousePrice(IProperty property)
    {
        Console.WriteLine("РеестрНедвижимости возвращает цену недвижимости");
        return property.Cost;
    }

    public static int GetHouseOwner(IProperty property)
    {
        Console.WriteLine("РеестрНедвижимости возвращает владельца недвижимости");
        return propertyOwners.GetValueOrDefault(property, -1);
    }

    public static PropertyRegistryMemento CreateMemento()
    {
        Console.WriteLine("РеестрНедвижимости создает Memento");
        return new PropertyRegistryMemento(new Dictionary<int, List<IProperty>>(playerProperties), new Dictionary<IProperty, int>(propertyOwners));
    }

    public static void Restore(PropertyRegistryMemento memento)
    {
        Console.WriteLine("РеестрНедвижимости восстанавливается из Memento");
        playerProperties = new Dictionary<int, List<IProperty>>(memento.PlayerProperties);
        propertyOwners = new Dictionary<IProperty, int>(memento.PropertyOwners);
    }
}
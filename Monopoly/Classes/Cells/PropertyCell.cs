using Monopoly.Classes.Game;
using Monopoly.Classes.IO;
using Monopoly.Interfaces;

namespace Monopoly.Classes.Cells;

public class PropertyCell : ICell
{
    public IProperty Property { get; }

    public PropertyCell(IProperty property)
    {
        Property = property;
    }

    public string GetInfo()
    {
        Console.WriteLine("КлеткаСНедвижимостью возвращает информацию о себе");
        return $"Клетка с недвижимостью (стоимость: {Property.Cost})";
    }

    public void Handle(int playerId)
    {
        Console.WriteLine($"КлеткаСНедвижимостью обрабатывает игрока {playerId}");
        int price = PropertyRegistry.GetHousePrice(Property);
        Console.WriteLine($"КлеткаСНедвижимостью вызывает PropertyRegistry.GetHousePrice и получает {price}");
        int owner = PropertyRegistry.GetHouseOwner(Property);
        Console.WriteLine($"КлеткаСНедвижимостью вызывает PropertyRegistry.GetHouseOwner и получает {owner}");

        if (owner != -1 && owner != playerId)
        {
            Console.WriteLine("КлеткаСНедвижимостью вызывает PropertyRegistry.PayRent (оплата аренды)");
            PropertyRegistry.PayRent(playerId, Property);
        }
        else if (owner == -1)
        {
            Console.WriteLine("КлеткаСНедвижимостью вызывает IOS.Input для вопроса о покупке");
            string answer = IOS.Input();
            if (answer == "yes")
            {
                Console.WriteLine("КлеткаСНедвижимостью вызывает PropertyRegistry.BuyHouse");
                PropertyRegistry.BuyHouse(playerId, Property);
            }
        }
    }
}
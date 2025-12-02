using Monopoly.Interfaces;

namespace Monopoly.Classes.Mementos;

public class PropertyRegistryMemento
{
    public Dictionary<int, List<IProperty>> PlayerProperties { get; }
    public Dictionary<IProperty, int> PropertyOwners { get; }

    public PropertyRegistryMemento(Dictionary<int, List<IProperty>> playerProperties, Dictionary<IProperty, int> propertyOwners)
    {
        PlayerProperties = playerProperties;
        PropertyOwners = propertyOwners;
    }
}
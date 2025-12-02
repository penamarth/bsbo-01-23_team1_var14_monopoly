namespace Monopoly.Classes.Mementos;

public class GameMemento
{
    public List<PlayerMemento> PlayerMementos { get; }
    public PropertyRegistryMemento PropertyRegistryMemento { get; }

    public GameMemento(List<PlayerMemento> playerMementos, PropertyRegistryMemento propertyRegistryMemento)
    {
        PlayerMementos = playerMementos;
        PropertyRegistryMemento = propertyRegistryMemento;
    }
}
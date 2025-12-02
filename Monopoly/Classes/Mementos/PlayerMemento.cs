namespace Monopoly.Classes.Mementos;

public class PlayerMemento
{
    public int Id { get; }
    public string Name { get; }
    public string Skin { get; }

    public PlayerMemento(int id, string name, string skin)
    {
        Id = id;
        Name = name;
        Skin = skin;
    }
}
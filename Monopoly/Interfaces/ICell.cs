namespace Monopoly.Interfaces;

public interface ICell
{
    void Handle(int playerId);
    string GetInfo();
}
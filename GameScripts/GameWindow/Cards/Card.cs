using MP_POO_FINAL.GameWindow.BoardInfo;
using MP_POO_FINAL.GameWindow.Characters;
using MP_POO_FINAL.Managers;
using Raylib_cs;

namespace MP_POO_FINAL.GameWindow.Cards;

public abstract class Card
{
    public OwnerType Owner {get; set;}
    public string Type {get; set;}
    public string Description {get; set;}
    public Color Color {get; set;}
    private Player player;
    public AI ai1;
    private AI ai2;

    protected Card(string type, string description,  OwnerType owner, Color color)
    {
        Type = type;
        Description = description;
        Owner = owner;
        Color = color;
    }

    public abstract void ActionCard(EventManager manager, OwnerType owner);
}
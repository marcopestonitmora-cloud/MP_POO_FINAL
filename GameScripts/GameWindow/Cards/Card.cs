using MP_POO_FINAL.GameWindow.BoardInfo;
using MP_POO_FINAL.GameWindow.Characters;
using MP_POO_FINAL.Managers;

namespace MP_POO_FINAL.GameWindow.Cards;

public abstract class Card
{
    public OwnerType Owner {get; set;}
    private string Type {get; set;}
    private string Description {get; set;}
    private Player player;
    public AI ai1;
    private AI ai2;

    protected Card(string type, string description,  OwnerType owner, Player player,  AI ai1, AI ai2)
    {
        Type = type;
        Description = description;
        Owner = owner;
        this.player = player;
        this.ai1 = ai1;
        this.ai2 = ai2;
    }

    public abstract void ActionCard(EventManager manager, OwnerType owner);
}
using MP_POO_FINAL.GameWindow.BoardInfo;
using MP_POO_FINAL.GameWindow.Characters;
using MP_POO_FINAL.Managers;

namespace MP_POO_FINAL.GameWindow.Cards.ActionCards;
public class TurnCard: Card
{
    public TurnCard(string type, string description, OwnerType owner, Player player, AI ai1, AI ai2) : base(type, description, owner, player, ai1, ai2)
    {
    }

    //TURNO DOBLE, EL JUGADOR VUELVE A JUGAR DESPUES DE SU TURNO
    public override void ActionCard(EventManager manager, OwnerType owner)
    {
        
    }
}
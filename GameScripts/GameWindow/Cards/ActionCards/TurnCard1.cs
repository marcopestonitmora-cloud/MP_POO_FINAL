using MP_POO_FINAL.GameWindow.BoardInfo;
using MP_POO_FINAL.GameWindow.Characters;
using MP_POO_FINAL.Managers;
using Raylib_cs;

namespace MP_POO_FINAL.GameWindow.Cards.ActionCards;
public class TurnCard1: Card
{
    public TurnCard1(string type, string description, OwnerType owner, Color color) : base(type, description, owner, color)
    {
    }

    //TURNO DOBLE, EL JUGADOR VUELVE A JUGAR DESPUES DE SU TURNO
    public override void ActionCard(EventManager manager, OwnerType user)
    {
        OwnerType[] characters = {OwnerType.Player, OwnerType.Ai1, OwnerType.Ai2};
        
        foreach (OwnerType rival in characters)
        {
            if (rival == user)
            {
                EventManager.Instance.GetCharacter(user).canRollAgain = true;   
            }
        }
    }
}
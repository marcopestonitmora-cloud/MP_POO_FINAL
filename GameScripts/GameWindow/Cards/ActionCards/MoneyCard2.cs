using MP_POO_FINAL.GameWindow.BoardInfo;
using MP_POO_FINAL.GameWindow.Characters;
using MP_POO_FINAL.Managers;

namespace MP_POO_FINAL.GameWindow.Cards.ActionCards;

public class MoneyCard2: Card
{
    public MoneyCard2(string type, string description, OwnerType owner) : base(type, description, owner)
    {
    }
    
    public override void ActionCard(EventManager manager, OwnerType owner)
    {
        LuckyStrike(owner);
    }

    //EL USUARIO GANARÁ LO QUE CUESTA EL NUMERO DE SU CASILLA * 10. CASILLA 25, GANAS 250
    private void LuckyStrike(OwnerType user)
    {
        int boardIndex;
        boardIndex = EventManager.Instance.GetCharacter(user).BoardPosition;
        EventManager.Instance.GetCharacter(user).WinInvicions(boardIndex * 10);
    }
}
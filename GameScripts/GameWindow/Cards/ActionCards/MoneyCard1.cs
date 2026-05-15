using MP_POO_FINAL.GameWindow.BoardInfo;
using MP_POO_FINAL.GameWindow.Characters;
using MP_POO_FINAL.Managers;

namespace MP_POO_FINAL.GameWindow.Cards.ActionCards;

public class MoneyCard1: Card
{
    public MoneyCard1(string type, string description, OwnerType owner) : base(type, description, owner)
    {
        
    }

    public override void ActionCard(EventManager manager, OwnerType owner)
    {
        Inflation(owner);
    }

    //CADA RIVAL PIERDE EL 25% DE SU DINERO Y EL QUE USA LA CARTA GANA ESE DINERO
    private void Inflation(OwnerType user)
    {
        OwnerType[] characters = {OwnerType.Player, OwnerType.Ai1, OwnerType.Ai2};
        int total = 0;
    
        foreach (OwnerType rival in characters)
        {
            if (rival == user)
            {
                continue;
            }
        
            //SE LE QUITA A CADA JUGADOR SU DINERO Y SE AÑADE EN LA VARIABLE TOTAL
            int loss = EventManager.Instance.GetCharacter(rival).Coins.Amount / 4;
            EventManager.Instance.GetCharacter(rival).LoseInvicions(loss);
            total += loss;
        }
        
        EventManager.Instance.GetCharacter(user).WinInvicions(total / 2);
    }
}
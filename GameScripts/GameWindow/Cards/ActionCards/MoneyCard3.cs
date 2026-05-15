using MP_POO_FINAL.GameWindow.BoardInfo;
using MP_POO_FINAL.GameWindow.Characters;
using MP_POO_FINAL.Managers;

namespace MP_POO_FINAL.GameWindow.Cards.ActionCards;

public class MoneyCard3: Card
{
    public MoneyCard3(string type, string description, OwnerType owner) : base(type, description, owner)
    {
    }
    
    public override void ActionCard(EventManager manager, OwnerType owner) 
    { 
        RevolutionaryTax(owner);
    }

    //EL RIVAL CON MAS DINERO LE PAGARÁ 200 AL QUE USE LA CARTA
    private void RevolutionaryTax(OwnerType user)
    {
        OwnerType[] characters = { OwnerType.Player, OwnerType.Ai1, OwnerType.Ai2 };
        OwnerType richest = OwnerType.None;
        int maxMoney = 0;

        foreach (OwnerType rival in characters)
        {
            if (rival == user) continue;

            int amount = EventManager.Instance.GetCharacter(rival).Coins.Amount;
            if (amount > maxMoney)
            {
                maxMoney = amount;
                richest  = rival;
            }
        }

        EventManager.Instance.GetCharacter(richest).LoseInvicions(200);
        EventManager.Instance.GetCharacter(user).WinInvicions(200);
    }
}
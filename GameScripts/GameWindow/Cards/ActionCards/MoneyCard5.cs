using MP_POO_FINAL.GameWindow.BoardInfo;
using MP_POO_FINAL.GameWindow.Characters;
using MP_POO_FINAL.Managers;
using Raylib_cs;

namespace MP_POO_FINAL.GameWindow.Cards.ActionCards;

public class MoneyCard5 : Card
{
    private int number;
    
    //Carta CoinFlip si sacas 0 duplicas tu dinero, si sacas 1 pierdes la mitad de tu dinero
    public MoneyCard5(string type, string description, OwnerType owner, Color color) : base(type, description, owner, color)
    {
    }

    public override void ActionCard(EventManager manager, OwnerType user)
    {
        Random random = new Random();
        number = random.Next(0,2);
        int money = EventManager.Instance.GetCharacter(user).Coins.Amount;

        if (number == 0)
        {
            EventManager.Instance.GetCharacter(user).WinInvicions(money);
        }
        else if (number == 1)
        {
            EventManager.Instance.GetCharacter(user).LoseInvicions(money);
        }
    }
}
using MP_POO_FINAL.GameWindow.BoardInfo;
using MP_POO_FINAL.GameWindow.Characters;
using MP_POO_FINAL.Managers;

namespace MP_POO_FINAL.GameWindow.Cards.ActionCards;

public class MoneyCard4: Card
{
    public MoneyCard4(string type, string description, OwnerType owner) : base(type, description, owner)
    {
    }

    public override void ActionCard(EventManager manager, OwnerType owner)
    {
        throw new NotImplementedException();
    }

    //TODOS LOS JUGADORES PIERDEN 100 INVICOINS
    private void EconomicCrisis(OwnerType user)
    {
        OwnerType[] characters = { OwnerType.Player, OwnerType.Ai1, OwnerType.Ai2 };

        foreach (OwnerType players in characters)
        {
            EventManager.Instance.GetCharacter(players).LoseInvicions(100);
        }
    }
}
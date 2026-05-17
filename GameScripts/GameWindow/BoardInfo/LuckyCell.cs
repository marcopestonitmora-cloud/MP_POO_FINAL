using System.Numerics;
using MP_POO_FINAL.GameWindow.Cards;
using MP_POO_FINAL.Managers;

namespace MP_POO_FINAL.GameWindow.BoardInfo;

public class LuckyCell: BoardCell
{
    public LuckyCell(int index, Vector2 screenPosition) : base(index, screenPosition) {}
    
    public override void OnLand(OwnerType currentPlayer)
    {
        Card card = EventManager.Instance.CardDeck.TakeCard();
        EventManager.Instance.AddCard(currentPlayer,card);
    }

    public override void DrawOnLandUI() {}
    public override void Buy(OwnerType currentPlayer) {}
    public override void Sell(OwnerType currentPlayer){}
}
using System.Numerics;
using MP_POO_FINAL.GameWindow.Cards;
using MP_POO_FINAL.Managers;

namespace MP_POO_FINAL.GameWindow.BoardInfo;

public class LuckyCell: BoardCell
{
    public LuckyCell(int index, Vector2 screenPosition) : base(index, screenPosition) {}
    
    public override void OnLand(OwnerType currentPlayer)
    {
        Console.WriteLine("Lucky Cell");
        Card card = EventManager.Instance.CardDeck.TakeCard();
        EventManager.Instance.AddCard(currentPlayer,card);
        Console.WriteLine($"Has obtenido {card.Description}");
    }

    public override void DrawOnLandUI() {}
    public override void Buy(OwnerType currentPlayer) {}
    public override void Sell(OwnerType currentPlayer){}
}
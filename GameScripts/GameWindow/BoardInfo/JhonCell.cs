using System.Numerics;
using MP_POO_FINAL.GameWindow.Cards;
using MP_POO_FINAL.GameWindow.Characters;
using MP_POO_FINAL.Managers;
using Raylib_cs;

namespace MP_POO_FINAL.GameWindow.BoardInfo;

public class JhonCell : BoardCell
{
    private Random random = new Random();
    
    public JhonCell(int index, Vector2 screenPosition) : base(index, screenPosition) {}

    public override void OnLand(OwnerType currentPlayer)
    {
        Character character = EventManager.Instance.GetCharacter(currentPlayer);

        //SI CAES EN LA CASILLA HAY UN 50% de que jhon te robe un carta y 50% de que te regale una carta
        if (random.Next(100) < 50)
        {
            if (character.Inventory.Count > 0)
            {
                int randomIndex = random.Next(character.Inventory.Count);
                character.Inventory.RemoveAt(randomIndex);
                Console.WriteLine("Jhon te ha robado una carta!");
            }
        }
        else
        {
            Card card = EventManager.Instance.CardDeck.TakeCard();
            EventManager.Instance.AddCard(currentPlayer, card);
            Console.WriteLine("Jhon te ha dado una carta!");
        }
    }

    public override void DrawOnLandUI()
    {
        Raylib.DrawText("INFO", 250, 990, 60, Color.White);
    }
    
    public override void Sell(OwnerType currentPlayer) {}
    public override void Buy(OwnerType currentPlayer) {}
}
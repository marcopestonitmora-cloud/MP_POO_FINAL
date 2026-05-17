using MP_POO_FINAL.GameWindow.BoardInfo;
using MP_POO_FINAL.GameWindow.Cards;
using MP_POO_FINAL.Managers;

namespace MP_POO_FINAL.GameWindow.Characters.StateMachine;

public class AICardLogic
{
    private AI ai;
    private Board board;
    private Random random = new Random();

    public AICardLogic(AI ai, Board board)
    {
        this.ai    = ai;
        this.board = board;
    }

    //Antes de tirar los dados la IA analiza su situacion para usar una carta o no
    public void UseCard()
    {
        if (ai.Inventory.Count == 0)
        {
            return;
        }

        Card moneyCard    = null;
        Card propertyCard = null;
        Card turnCard     = null;

        foreach (Card card in ai.Inventory)
        {
            if (card.Type == "Money" && moneyCard == null)
            {
                moneyCard    = card;
            }
            if (card.Type == "Property" && propertyCard == null)
            {
                propertyCard = card;
            }
            {
                if (card.Type == "Turn"     && turnCard     == null) turnCard     = card;
            }
        }

        int propertyCount = CountProperties();
        int buyChance;
        if (propertyCount < 2)
        {
            buyChance = 70;
        }
        else
        {
            buyChance = 40;
        }
        
        //Si tiene menos de 150 inivcoins y una moneyCard usa la money Card
        if (ai.Coins.Amount < 150 && moneyCard != null)
        {
            PlayCard(moneyCard);
            return;
        }

        //Dependiendo de la cantidad de propiedades cuantas mas tenga menos probailidad de uso de carta de tipo property, si tiene menos de dos 70%
        if (propertyCard != null && random.Next(100) < buyChance)
        {
            PlayCard(propertyCard);
            return;
        }

        //Si tiene mas de 400 monedas hay un 30% de que use una Turn Card
        if (ai.Coins.Amount > 400 && turnCard != null && random.Next(100) < 30)
        {
            PlayCard(turnCard);
        }
    }

    private int CountProperties()
    {
        int count = 0;
        foreach (BoardCell cell in board.GetAllCells())
        {
            PropertyCell property = cell as PropertyCell;
            
            if (property != null && property.Owner == ai.OwnerType)
            {
                count++;
            }
            
            MonsterCell monster = cell as MonsterCell;
            if (monster != null && monster.Owner == ai.OwnerType)
            {
                count++;
            }
        }
        return count;
    }

    private void PlayCard(Card card)
    {
        Console.WriteLine($"{ai.OwnerType} usa carta: {card.Type} - {card.Description}");
        card.ActionCard(EventManager.Instance, ai.OwnerType);
        ai.Inventory.Remove(card);
    }
}
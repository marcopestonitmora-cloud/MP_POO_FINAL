using MP_POO_FINAL.GameWindow.BoardInfo;

namespace MP_POO_FINAL.GameWindow.Characters.StateMachine;

public class AIBuyLogic
{
    private AI ai;
    private Board board;
    private Random random = new Random();

    public AIBuyLogic(AI ai, Board board)
    {
        this.ai    = ai;
        this.board = board;
    }
    
    public void OnLand()
    {
        BoardCell cell = board.GetCellIndex(ai.BoardPosition);

        PropertyCell property = cell as PropertyCell;
        MonsterCell  monster  = cell as MonsterCell;

        if (property != null)
        {
            HandleProperty(property);
        }
        else if (monster != null)
        {
            HandleMonster(monster);
        }
    }

    //Si la IA cae en una propiedad y no es suya. Si tiene el precio de la casilla + 200, la compra automaticamente. 
    //Si tiene más del precio de la casilla pero no +200 adicionales, hay un 60% de que la compre.
    //Si la casilla ya es suya analiza si comprar creditos.
    private void HandleProperty(PropertyCell property)
    {
        if (property.Owner == OwnerType.None)
        {
            if (ai.Coins.Amount > property.Price + 200)
            {
                property.Buy(ai.OwnerType);
            }
            else if (ai.Coins.Amount > property.Price && random.Next(100) < 60)
            {
                property.Buy(ai.OwnerType);
            }
        }
        else if (property.Owner == ai.OwnerType)
        {
            TryBuyCredits(property);
        }
    }

    //Igual que con las propertyCells
    private void HandleMonster(MonsterCell monster)
    {
        if (monster.Owner == OwnerType.None)
        {
            if (ai.Coins.Amount > monster.Price + 200)
            {
                monster.Buy(ai.OwnerType);
            }
            else if (ai.Coins.Amount > monster.Price && random.Next(100) < 60)
            {
                monster.Buy(ai.OwnerType);
            }
        }
    }

    //Si ya tiene la casilla comprada y tiene mas de 400 monedas compra instant, si no tiene aun los seis, compra un segundo credito.
    //Si tiene mas de 200 hay un 50% de que compre un credito
    private void TryBuyCredits(PropertyCell property)
    {
        if (ai.Coins.Amount > 400)
        {
            property.Buy(ai.OwnerType);
            if (ai.Coins.Amount > 400 && property.CreditCounter < 6)
            {
                property.Buy(ai.OwnerType);
            }
        }
        else if (ai.Coins.Amount > 200 && random.Next(100) < 50)
        {
            property.Buy(ai.OwnerType);
        }
    }
}
using MP_POO_FINAL.GameWindow.BoardInfo;
using MP_POO_FINAL.Managers;

namespace MP_POO_FINAL.GameWindow.Characters.StateMachine;

public class AISellLogic
{
    private AI ai;
    private Random rnd = new Random();

    public AISellLogic(AI ai)
    {
        this.ai = ai;
    }

    public void EvaluateSell()
    {
        //Si tiene más de 150 invicions no se plantea vender
        if (ai.Coins.Amount >= 150)
        {
            return;
        }

        BoardCell cell = EventManager.Instance.board.GetCellIndex(ai.BoardPosition);
        PropertyCell property = cell as PropertyCell;

        if (property == null || property.Owner != ai.OwnerType)
        {
            return;
        }

        //La ia si tiene menos de 150 priorizará vender los creditos a vender la propiedad
        while (ai.Coins.Amount < 150 && property.CreditCounter > 0)
        {
            property.Sell(ai.OwnerType);
        }

        //Vuelve a comprobar si dps de vender los creditos pasa de 150
        if (ai.Coins.Amount >= 150)
        {
            return;
        }

        int propertyCount = PropertyCounter();

        //Sino llega a 150 dps de vender los creditos. Si tiene menos o 2 propiedades vende esa propiedad.
        //Si tiene mas de 5 propiedades hay un 20% de posibilidades de que venda la propiedad
        if (propertyCount <= 2)
        {
            property.Sell(ai.OwnerType);
        }
        else if (propertyCount > 5 && rnd.Next(100) < 20)
        {
            property.Sell(ai.OwnerType);
        }
    }
    
    private int PropertyCounter()
    {
        int count = 0;
        foreach (BoardCell cell in EventManager.Instance.board.GetAllCells())
        {
            PropertyCell prop = cell as PropertyCell;
            if (prop != null && prop.Owner == ai.OwnerType)
                count++;

            MonsterCell monster = cell as MonsterCell;
            if (monster != null && monster.Owner == ai.OwnerType)
                count++;
        }
        return count;
    }
}
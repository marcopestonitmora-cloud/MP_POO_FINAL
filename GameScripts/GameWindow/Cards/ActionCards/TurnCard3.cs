using MP_POO_FINAL.GameWindow.BoardInfo;
using MP_POO_FINAL.GameWindow.Characters;
using MP_POO_FINAL.Managers;

namespace MP_POO_FINAL.GameWindow.Cards.ActionCards;

public class TurnCard3 : Card
{
    private Board Board;
    
    public TurnCard3(string type, string description, OwnerType owner, Player player, AI ai1, AI ai2, Board board) : base(type, description, owner, player, ai1, ai2)
    {
        this.Board = board;
    }

    //Esta carta te teletransporta a tu propiedad mas cara
    public override void ActionCard(EventManager manager, OwnerType user)
    {
        int expensiveCellIndex = 0;
        foreach (BoardCell cell in Board.GetAllCells())
        {
            if (cell is PropertyCell property && cell.CellOwner == user)
            {
                expensiveCellIndex = cell.Index;
            }
        }

        EventManager.Instance.GetCharacter(user).BoardPosition = expensiveCellIndex;
    }
}
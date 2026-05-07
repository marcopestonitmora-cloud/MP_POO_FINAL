using System.Numerics;
using MP_POO_FINAL.GameWindow.BoardInfo;
using MP_POO_FINAL.GameWindow.Invicoins;

namespace MP_POO_FINAL.GameWindow.Characters;

public abstract class Character
{
    private int BoardPosition { get; set; } = 0;
    public Vector2 ScreenPosition {get; private set;}
    //public Inventory<ActionCard> Cards { get; protected set; }
    public List<PropertyCell> Properties { get; protected set; }
    public bool IsBankrupt { get; protected set; } = false;
    protected abstract OwnerType OwnerType { get; }
    public DrawInvicoins Coins {get; set;}

    protected Character(int invicoinsCounter)
    {
        Coins = new DrawInvicoins(invicoinsCounter);
        ScreenPosition = Vector2.Zero;
    }

    public virtual void Move (int diceNumber, Board board)
    {
        BoardPosition = (BoardPosition + diceNumber) % board.CellCounter;
        ScreenPosition = board.GetCellIndex(BoardPosition).ScreenPosition;
        board.GetCellIndex(BoardPosition).OnLand(OwnerType);
    }
}
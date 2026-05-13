using System.Numerics;
using MP_POO_FINAL.GameWindow.BoardInfo;
using MP_POO_FINAL.GameWindow.Invicoins;
using MP_POO_FINAL.Managers;

namespace MP_POO_FINAL.GameWindow.Characters;

public abstract class Character
{
    public int BoardPosition { get; set; } = 0;
    public Vector2 ScreenPosition {get; private set;}
    //public Inventory<ActionCard> Cards { get; protected set; }
    public bool IsBankrupt { get; protected set; } = false;
    protected abstract OwnerType OwnerType { get; }
    private int CurrentPosition {get; set;} = 0;
    public DrawInvicoins Coins {get; set;}
    public bool canRollAgain { get; set; } = false;

    protected Character(int invicoinsCounter)
    {
        Coins = new DrawInvicoins(invicoinsCounter);
        ScreenPosition = new Vector2(1370, 960);
    }

    public virtual async Task Move(int diceNumber, Board board)
    { 
        CurrentPosition = (BoardPosition) % board.CellCounter;
        BoardPosition = (BoardPosition + diceNumber) % board.CellCounter;

        await CellJump(CurrentPosition, diceNumber, board);
    
        Console.WriteLine($"Llamando OnLand en casilla {BoardPosition} con {OwnerType}");
        board.GetCellIndex(BoardPosition).OnLand(OwnerType);
    }

    protected virtual async Task CellJump(int currentPosition, int steps, Board board)
    {
        for (int i = 1; i <= steps; i++)
        {
            int nextPosition = (currentPosition + i) % board.CellCounter;

            //Si nos encontramos en la casilla de inicio y aun nos quedan movimientos por dar se llama al metodo OnPass de la startCell
            if (nextPosition == 0 && i < steps)
            {
                StartCell startCell = board.GetCellIndex(0) as StartCell;
                startCell?.OnPass(OwnerType);
            }
            
            ScreenPosition = board.GetCellIndex(nextPosition).ScreenPosition;
            
            await Task.Delay(500);
        }
    }

    public virtual void LoseInvicions(int cellPrice)
    {
        if (Coins.Amount < cellPrice)
        {
            return;
        }
        
        Coins.Amount -= cellPrice;
        
        if (Coins.Amount <= 0)
        {
            IsBankrupt = true;
        }
    }

    public virtual void WinInvicions(int cellPrice)
    {
        Coins.Amount += cellPrice;
    }
}
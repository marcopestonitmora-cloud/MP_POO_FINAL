using System.Numerics;
using MP_POO_FINAL.GameWindow.BoardInfo;
using MP_POO_FINAL.GameWindow.Invicoins;
using MP_POO_FINAL.Managers;

namespace MP_POO_FINAL.GameWindow.Characters;

public class Player: Character
{
    public event Action OnRollEnd;
    
    public Player(int invicoinsCounter, OwnerType ownerType) : base(invicoinsCounter)
    {
        OwnerType = ownerType;
    }

    protected override OwnerType OwnerType { get; }

    public override async Task Move (int diceNumber, Board board)
    {
        await base.Move(diceNumber, board);
    }

    protected override async Task CellJump(int currentPosition, int steps, Board board)
    {
         await base.CellJump(currentPosition, steps, board);

         await Task.Delay(3000);
         
        OnRollEnd?.Invoke();
    }
}
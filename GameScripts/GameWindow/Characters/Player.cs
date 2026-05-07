using System.Numerics;
using MP_POO_FINAL.GameWindow.BoardInfo;
using MP_POO_FINAL.GameWindow.Invicoins;

namespace MP_POO_FINAL.GameWindow.Characters;

public class Player: Character
{
    protected override OwnerType OwnerType { get; }
    
    public Player(int invicoinsCounter, OwnerType ownerType) : base(invicoinsCounter)
    {
        OwnerType = ownerType;
    }

    public override void Move (int diceNumber, Board board)
    {
        base.Move(diceNumber, board);
    }
}
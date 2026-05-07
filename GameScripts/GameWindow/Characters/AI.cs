using System.Numerics;
using MP_POO_FINAL.GameWindow.BoardInfo;
using MP_POO_FINAL.GameWindow.Invicoins;

namespace MP_POO_FINAL.GameWindow.Characters;

public class AI : Character
{
    public AI(int invicoinsCounter,  OwnerType ownerType) : base(invicoinsCounter)
    {
        OwnerType = ownerType;
    }

    protected override OwnerType OwnerType { get; }
    


    public override void Move (int diceNumber, Board board)
    {
        base.Move(diceNumber, board);
    }
}
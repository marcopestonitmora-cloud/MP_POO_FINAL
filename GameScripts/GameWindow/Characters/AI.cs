using System.Numerics;
using MP_POO_FINAL.GameScripts.Events;
using MP_POO_FINAL.GameWindow.BoardInfo;
using MP_POO_FINAL.Managers;

namespace MP_POO_FINAL.GameWindow.Characters;

public class AI : Character
{
    public AI(int invicoinsCounter, OwnerType ownerType) : base(invicoinsCounter)
    {
        OwnerType = ownerType;
    }

    public override OwnerType OwnerType { get; }

    public override async Task Move(int diceNumber, Board board)
    {
        EventManager.Instance.IsAnimating = true;
        await base.Move(diceNumber, board);
        
        await Task.Delay(2000);
        
        EventManager.Instance.IsAnimating = false;
    }
}
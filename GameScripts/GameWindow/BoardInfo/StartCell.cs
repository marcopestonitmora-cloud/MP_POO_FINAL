using System.Numerics;

namespace MP_POO_FINAL.GameWindow.BoardInfo;

public class StartCell: BoardCell
{
    public int InvicoinsPay {get; private set; }

    public StartCell(int index, string name, Vector2 screenPosition, int invicoinsPay) : base(index, name, screenPosition)
    {
        InvicoinsPay = invicoinsPay;
    }
    
    public override void OnLand(OwnerType currentPlayer)
    {
        throw new NotImplementedException();
    }
}
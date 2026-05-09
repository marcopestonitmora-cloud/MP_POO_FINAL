using System.Numerics;

namespace MP_POO_FINAL.GameWindow.BoardInfo;

public class StartCell: BoardCell
{
    public int InvicoinsPay {get; private set; }

    public StartCell(int index, Vector2 screenPosition, int invicoinsPay) : base(index, screenPosition)
    {
        InvicoinsPay = invicoinsPay;
    }
    
    public override void OnLand(OwnerType currentPlayer)
    {
        
    }

    public override void DrawOnLandUI()
    {
        
    }
}
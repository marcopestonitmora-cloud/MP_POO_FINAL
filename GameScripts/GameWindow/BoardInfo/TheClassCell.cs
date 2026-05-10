using System.Numerics;

namespace MP_POO_FINAL.GameWindow.BoardInfo;

public class TheClassCell: BoardCell
{
    public TheClassCell(int index, Vector2 screenPosition) : base(index, screenPosition) {}
    
    public override void OnLand(OwnerType currentPlayer)
    {
        Console.WriteLine("TheClassCell");
    }

    public override void DrawOnLandUI()
    {
        
    }
    
    public override void Buy(OwnerType currentPlayer) {}
    public override void Sell(OwnerType currentPlayer){}
}
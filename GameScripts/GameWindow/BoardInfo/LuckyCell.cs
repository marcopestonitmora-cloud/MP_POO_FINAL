using System.Numerics;

namespace MP_POO_FINAL.GameWindow.BoardInfo;

public class LuckyCell: BoardCell
{
    public LuckyCell(int index, Vector2 screenPosition) : base(index, screenPosition) {}
    
    public override void OnLand(OwnerType currentPlayer)
    {
        Console.WriteLine("Lucky Cell");
    }

    public override void DrawOnLandUI()
    {
        
    }
}
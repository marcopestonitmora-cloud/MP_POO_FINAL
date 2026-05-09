using System.Numerics;

namespace MP_POO_FINAL.GameWindow.BoardInfo;

public class DoorCell: BoardCell
{
    public DoorCell(int index, Vector2 screenPosition) : base(index, screenPosition) {}
    
    public override void OnLand(OwnerType currentPlayer)
    {
        Console.WriteLine("DoorCell");
    }

    public override void DrawOnLandUI()
    {
        
    }
}
using System.Numerics;

namespace MP_POO_FINAL.GameWindow.BoardInfo;

public class DoorCell: BoardCell
{
    public DoorCell(int index, string name, Vector2 screenPosition) : base(index, name, screenPosition) {}
    
    public override void OnLand(OwnerType currentPlayer)
    {
        Console.WriteLine("DoorCell");
    }

    public override void DrawOnLandUI()
    {
        
    }
}
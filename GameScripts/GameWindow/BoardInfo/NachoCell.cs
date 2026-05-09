using System.Numerics;

namespace MP_POO_FINAL.GameWindow.BoardInfo;

public class NachoCell: BoardCell
{
    public NachoCell(int index, Vector2 screenPosition) : base(index, screenPosition) {}
    
    public override void OnLand(OwnerType currentPlayer)
    {
        Console.WriteLine("Nacho Cell");
    }

    public override void DrawOnLandUI()
    {
        
    }
}
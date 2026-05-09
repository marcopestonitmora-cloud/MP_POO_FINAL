using System.Numerics;

namespace MP_POO_FINAL.GameWindow.BoardInfo;

public class NachoCell: BoardCell
{
    public NachoCell(int index, string name, Vector2 screenPosition) : base(index, name, screenPosition) {}
    
    public override void OnLand(OwnerType currentPlayer)
    {
        Console.WriteLine("Nacho Cell");
    }

    public override void DrawOnLandUI()
    {
        
    }
}
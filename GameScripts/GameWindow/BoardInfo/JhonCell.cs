using System.Numerics;

namespace MP_POO_FINAL.GameWindow.BoardInfo;

public class JhonCell: BoardCell
{
    public JhonCell(int index, Vector2 screenPosition) : base(index, screenPosition) {}
    
    public override void OnLand(OwnerType currentPlayer)
    {
        Console.WriteLine("Jhon Cell");
    }

    public override void DrawOnLandUI()
    {
        
    }
}
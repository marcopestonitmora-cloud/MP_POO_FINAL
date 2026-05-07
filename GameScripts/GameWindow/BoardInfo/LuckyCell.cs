using System.Numerics;

namespace MP_POO_FINAL.GameWindow.BoardInfo;

public class LuckyCell: BoardCell
{
    public LuckyCell(int index, string name, Vector2 screenPosition) : base(index, name, screenPosition) {}
    
    public override void OnLand(OwnerType currentPlayer)
    {
        Console.WriteLine("Lucky Cell");
    }
}
using System.Numerics;

namespace MP_POO_FINAL.GameWindow.BoardInfo;

public class TheClassCell: BoardCell
{
    public TheClassCell(int index, string name, Vector2 screenPosition) : base(index, name, screenPosition) {}
    
    public override void OnLand(OwnerType currentPlayer)
    {
        throw new NotImplementedException();
    }
}
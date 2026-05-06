using System.Numerics;

namespace MP_POO_FINAL.GameScripts.GameWindow.Board;

public class JhonCell: BoardCell
{
    public JhonCell(int index, string name, Vector2 screenPosition) : base(index, name, screenPosition) {}
    
    public override void OnLand(OwnerType currentPlayer)
    {
        throw new NotImplementedException();
    }
}
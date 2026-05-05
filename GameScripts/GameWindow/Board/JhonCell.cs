using System.Numerics;

namespace MP_POO_FINAL;

public class JhonCell: BoardCell
{
    public JhonCell(int index, string name, Vector2 screenPosition) : base(index, name, screenPosition) {}
    
    public override void OnLand(OwnerType currentPlayer)
    {
        throw new NotImplementedException();
    }
}
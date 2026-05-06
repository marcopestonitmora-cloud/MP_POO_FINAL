using System.Numerics;

namespace MP_POO_FINAL.GameScripts.GameWindow.Board;

public class MonsterCell: BoardCell
{
    public OwnerType Owner    { get; set; }
    public int Price          { get; private set; }
    public int RentPrice          { get; private set; }
    
    public MonsterCell(int index, string name, Vector2 screenPosition, int price, int rentPrice) : base(index, name, screenPosition)
    {
        Owner = OwnerType.None;
        Price = price;
        RentPrice = rentPrice;
    }
    
    public override void OnLand(OwnerType currentPlayer)
    {
        throw new NotImplementedException();
    }
}
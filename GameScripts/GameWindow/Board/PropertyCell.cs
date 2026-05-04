using System.Numerics;

namespace MP_POO_FINAL;

public enum OwnerType { None, Player, Ai1, Ai2 }

public class PropertyCell: BoardCell
{
    public string Color       { get; private set; }
    public int Price          { get; private set; }
    public OwnerType Owner    { get; set; }
    public int CreditPrice    { get; private set; }
    public int RentPrice      { get; private set; }
    
    public PropertyCell(int index, string name, Vector2 screenPosition, string color, int price, int owner, int creditPrice, int rentPrice) : base(index,name, screenPosition)
    {
        Color = color;
        Price = price;
        Owner = OwnerType.None;
        CreditPrice = creditPrice;
        RentPrice = rentPrice;
    }
    
    public override void OnLand(OwnerType currentPlayer)
    {
        throw new NotImplementedException();
    }
}
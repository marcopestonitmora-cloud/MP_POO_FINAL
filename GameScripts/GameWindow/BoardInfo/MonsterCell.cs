using System.Diagnostics;
using System.Numerics;
using MP_POO_FINAL.Managers;
using Raylib_cs;

namespace MP_POO_FINAL.GameWindow.BoardInfo;

public class MonsterCell: BoardCell
{
    public int Price          { get; set; }
    private int RentPrice          { get; set; }
    private int SellPrice         { get; set; }
    public Color Color;
    
    public MonsterCell(int index,Vector2 screenPosition, int price, int rentPrice, int sellPrice, Color color) : base(index, screenPosition)
    {
        Owner = OwnerType.None;
        Price = price;
        RentPrice = rentPrice;
        SellPrice = sellPrice;
        Color = color;
    }
    
    public override void OnLand(OwnerType currentPlayer)
    {
        if (Owner == OwnerType.None || currentPlayer == Owner)
        {
            return;
        }
        
        EventManager.Instance.GetCharacter(currentPlayer).LoseInvicions(RentPrice);
        EventManager.Instance.GetCharacter(Owner).WinInvicions(RentPrice);
    }
    
    public override void Buy(OwnerType buyer)
    {
        if (Owner == buyer)
        {
            return;
        }
        
        if (Owner == OwnerType.None)
        {
            EventManager.Instance.GetCharacter(buyer).LoseInvicions(Price);
            Owner = buyer;
        }
    }

    public override void Sell(OwnerType seller)
    {
        Owner = OwnerType.None;
        EventManager.Instance.GetCharacter(seller).WinInvicions(SellPrice);
    }
    
    public override bool CanBuy(OwnerType buyer)
    {
        return Owner == OwnerType.None;
    }
    
    public override bool CanSell(OwnerType seller) => Owner == seller;
}
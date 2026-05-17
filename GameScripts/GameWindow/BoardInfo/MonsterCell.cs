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
        if (Owner == OwnerType.None || currentPlayer == Owner) return;

        int rent = RentPrice;
        int playerMoney = EventManager.Instance.GetCharacter(currentPlayer).Coins.Amount;

        if (playerMoney < rent)
        {
            rent = playerMoney; 
        }

        EventManager.Instance.GetCharacter(currentPlayer).LoseInvicions(rent);
        EventManager.Instance.GetCharacter(Owner).WinInvicions(rent);
    }
    
    public override void Buy(OwnerType buyer)
    {
        if (Owner == buyer) return;
    
        if (Owner == OwnerType.None)
        {
            if (EventManager.Instance.GetCharacter(buyer).Coins.Amount < Price) return;
        
            Owner = buyer;
            EventManager.Instance.GetCharacter(buyer).LoseInvicions(Price);
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
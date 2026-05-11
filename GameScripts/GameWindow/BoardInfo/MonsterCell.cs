using System.Diagnostics;
using System.Numerics;
using MP_POO_FINAL.Managers;
using Raylib_cs;

namespace MP_POO_FINAL.GameWindow.BoardInfo;

public class MonsterCell: BoardCell
{
    private int Price          { get; set; }
    private int RentPrice          { get; set; }
    private int SellPrice         { get; set; }
    
    
    public MonsterCell(int index,Vector2 screenPosition, int price, int rentPrice, int sellPrice) : base(index, screenPosition)
    {
        Owner = OwnerType.None;
        Price = price;
        RentPrice = rentPrice;
        SellPrice = sellPrice;
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

    public override void DrawOnLandUI()
    {
        switch(Owner)
        {
            case OwnerType.None:
            {
                Raylib.DrawTextureEx(buyIcone, new Vector2(57, 860), 0, 0.6f, Color.White);
                Raylib.DrawText(buyText, 70, 990, 60, Color.White);
                break;
            }
            case OwnerType.Player:
            {
                Raylib.DrawText(sellText, 1500, 600, 50, Color.White);
                break;
            }
        }
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
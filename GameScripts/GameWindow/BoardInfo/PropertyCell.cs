using System.Diagnostics;
using System.Numerics;
using MP_POO_FINAL.Managers;
using Raylib_cs;

namespace MP_POO_FINAL.GameWindow.BoardInfo;

public enum OwnerType { None, Player, Ai1, Ai2 }

public class PropertyCell: BoardCell
{
    private int Price          { get; set; }
    private int CreditPrice    { get; set; }
    private int RentPrice      { get; set; }
    private int CreditCounter { get; set; }
    private int SellPrice      { get; set; }

    public PropertyCell(int index, Vector2 screenPosition, int price, int creditPrice, int creditCounter, int rentPrice, int sellPrice) : base(index, screenPosition)
    {
        CreditCounter = creditCounter;
        Price = price;
        Owner = OwnerType.None;
        CreditPrice = creditPrice;
        RentPrice = rentPrice;
        SellPrice = sellPrice;
    }

    public override void OnLand(OwnerType currentPlayer)
    {
        if (Owner == OwnerType.None || currentPlayer == Owner)
        {
            return;
        }

        int rent = RentPrice;

        if (CreditCounter >= 1)
        {
            rent = RentPrice * 2;
        }
        if (CreditCounter >= 3)
        {
            rent = RentPrice * 4;
        }
        if (CreditCounter >= 6)
        {
            rent = RentPrice * 8;
        }

        EventManager.Instance.GetCharacter(currentPlayer).LoseInvicions(rent);
        EventManager.Instance.GetCharacter(Owner).WinInvicions(rent);
    }
    
    // En PropertyCell
    public override void Buy(OwnerType buyer)
    {
        if (Owner == OwnerType.None)
        {
            Owner = buyer;
            EventManager.Instance.GetCharacter(buyer).LoseInvicions(Price);
        }
        
        else if (Owner == buyer)
        {
            EventManager.Instance.GetCharacter(buyer).LoseInvicions(CreditPrice);
            CreditCounter++;
            Console.WriteLine("CreditCounter: " + CreditCounter);
        }
        else
        {
            throw new InvalidOperationException("Esta propiedad pertenece a otro jugador.");
        }
    }

    public override void Sell(OwnerType seller)
    {
        Owner = OwnerType.None;
        EventManager.Instance.GetCharacter(seller).WinInvicions(SellPrice);
    }
    
    public override bool CanBuy(OwnerType buyer)
    {
        if (Owner == OwnerType.None)
        {
            return true;
        }

        if (Owner == buyer && CreditCounter < 6)
        {
            return true;
        }
        
        return false;
    }
    
    public override bool CanSell(OwnerType seller) => Owner == seller;
}
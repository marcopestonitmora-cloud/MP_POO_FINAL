using System.Diagnostics;
using System.Numerics;
using MP_POO_FINAL.Managers;
using Raylib_cs;

namespace MP_POO_FINAL.GameWindow.BoardInfo;

public class PropertyCell: BoardCell
{
    public int Price          { get; set; }
    private int CreditPrice    { get; set; }
    public int RentPrice      { get; set; }
    public int CreditCounter { get; set; }
    private int SellPrice      { get; set; }
    public Color Color { get; set; }

    public PropertyCell(int index, Vector2 screenPosition, int price, int creditPrice, int creditCounter, int rentPrice, int sellPrice, Color color) : base(index, screenPosition)
    {
        CreditCounter = creditCounter;
        Price = price;
        Owner = OwnerType.None;
        CreditPrice = creditPrice;
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
            EventManager.Instance.GetCharacter(buyer).LoseInvicions(Price);
            Owner = buyer;
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
        while (CreditCounter > 0)
        {
            CreditCounter--;
            EventManager.Instance.GetCharacter(seller).WinInvicions(CreditPrice - (CreditCounter/10));
            return;
        }

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
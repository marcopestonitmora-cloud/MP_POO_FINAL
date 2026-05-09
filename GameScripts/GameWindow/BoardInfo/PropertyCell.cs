using System.Diagnostics;
using System.Numerics;
using MP_POO_FINAL.Managers;
using Raylib_cs;

namespace MP_POO_FINAL.GameWindow.BoardInfo;

public enum OwnerType { None, Player, Ai1, Ai2 }

public class PropertyCell: BoardCell
{
    private int Price          { get; set; }
    public OwnerType Owner    { get; set; }
    public int CreditPrice    { get; private set; }
    public int RentPrice      { get; private set; }

    public int CreditCounter { get; set; }
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

        EventManager.Instance.GetCharacter(currentPlayer).PayCell(rent);
    }

    public override void DrawOnLandUI()
    {
        switch (Owner)
        {
            case OwnerType.None:
            {
                Raylib.DrawTextureEx(buyIcone, new Vector2(57, 860), 0, 0.6f, Color.White);
                Raylib.DrawText(buyText, 70, 990, 60, Color.White);
                break;
            }
            case OwnerType.Player:
            {
                Raylib.DrawTextureEx(buyIcone, new Vector2(57, 860), 0, 0.6f, Color.White);
                Raylib.DrawText(buyText, 70, 990, 60, Color.White);
                Raylib.DrawText(sellText, 70, 760, 60, Color.White);
                break;
            }
        }
    }
    
    // En PropertyCell
    public void Buy(OwnerType buyer)
    {
        if (Owner == OwnerType.None)
        {
            Owner = buyer;
            EventManager.Instance.GetCharacter(buyer).PayCell(Price);
        }
        
        if (Owner == buyer)
        {
            EventManager.Instance.GetCharacter(buyer).PayCell(CreditPrice);
            CreditCounter++;
            Console.WriteLine("CreditCounter: " + CreditCounter);
        }
        else
        {
            throw new InvalidOperationException("Esta propiedad pertenece a otro jugador.");
        }
    }

    public void Sell(OwnerType seller)
    {
        Owner = OwnerType.None;
        EventManager.Instance.GetCharacter(seller).SellCell(SellPrice);
    }
}
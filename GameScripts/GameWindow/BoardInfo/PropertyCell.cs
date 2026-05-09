using System.Diagnostics;
using System.Numerics;
using MP_POO_FINAL.Managers;
using Raylib_cs;

namespace MP_POO_FINAL.GameWindow.BoardInfo;

public enum OwnerType { None, Player, Ai1, Ai2 }

public class PropertyCell: BoardCell
{
    private int Price          { get; set; }
    private OwnerType Owner    { get; set; }
    public int CreditPrice    { get; private set; }
    public int RentPrice      { get; private set; }
    
    public int SellPrice      { get; private set; }

    public PropertyCell(int index, string name, Vector2 screenPosition, string color, int price, int creditPrice, int rentPrice, int sellPrice) : base(index,name, screenPosition)
    {
        Price = price;
        Owner = OwnerType.None;
        CreditPrice = creditPrice;
        RentPrice = rentPrice;
        SellPrice = sellPrice;
    }

    public override void OnLand(OwnerType currentPlayer)
    {
     
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
                Raylib.DrawText(sellText, 70, 600, 60, Color.White);
                break;
            }
        }
    }
    
    // En PropertyCell
    public void Buy(OwnerType buyer)
    {
        if (Owner != OwnerType.None)
        {
            throw new InvalidCastException("Esta propiedad ya tiene dueño.");
        }
    
        Owner = buyer;
        EventManager.Instance.GetCharacter(buyer).BuyCell(Price);
    }
}
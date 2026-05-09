using System.Diagnostics;
using System.Numerics;
using Raylib_cs;

namespace MP_POO_FINAL.GameWindow.BoardInfo;

public class MonsterCell: BoardCell
{
    public OwnerType Owner    { get; set; }
    public int Price          { get; private set; }
    public int RentPrice          { get; private set; }
    
    public MonsterCell(int index,Vector2 screenPosition, int price, int rentPrice) : base(index, screenPosition)
    {
        Owner = OwnerType.None;
        Price = price;
        RentPrice = rentPrice;
    }
    
    public override void OnLand(OwnerType currentPlayer)
    {
        Console.WriteLine("Monster cell");
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
}
using System.Numerics;
using Raylib_cs;

namespace MP_POO_FINAL.GameWindow.BoardInfo;

public enum OwnerType { None, Player, Ai1, Ai2 }

public abstract class BoardCell
{
    public int Index { get; private set; }
    public Vector2 ScreenPosition { get; private set; }
    protected OwnerType Owner { get; set; }
    public OwnerType CellOwner
    {
        get => Owner;
        set => Owner = value;
    }

    protected Texture2D buyIcone;
    protected Texture2D sellIcone;
    protected string buyText = "BUY";
    protected string sellText = "SELL";

    protected BoardCell(int index, Vector2 screenPosition)
    {
        if (index < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        Index          = index;
        ScreenPosition = screenPosition;
    }
    
    public virtual void LoadAssets()
    {
        buyIcone = Raylib.LoadTexture("Sprites/IV_money.png");
        sellIcone =  Raylib.LoadTexture("Sprites/SellIcone.png");
    }

    public abstract void OnLand(OwnerType currentPlayer);  
    
    public virtual void DrawOnLandUI()
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
                Raylib.DrawTextureEx(sellIcone, new Vector2(-120, 500), 0, 0.8f, Color.White);
                Raylib.DrawText(buyText, 70, 990, 60, Color.White);
                Raylib.DrawText(sellText, 70, 760, 60, Color.White);
                break;
            }
        }
    }
    
    public virtual bool CanBuy(OwnerType buyer) => false;
    public virtual bool CanSell(OwnerType seller) => false;
    public abstract void Sell(OwnerType currentPlayer);
    public abstract void Buy(OwnerType currentPlayer);
    //Metodo para cuando el player cae en dicha casilla. Permite comprarla o pagar al propietario si no esta ocupada.
    //Si la compra le dan una tarjeta de accion aleatoria
    //Si tiene propietario que salte el evento y le pague
}
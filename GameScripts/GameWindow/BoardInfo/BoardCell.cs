using System.Numerics;
using Raylib_cs;

namespace MP_POO_FINAL.GameWindow.BoardInfo;

public abstract class BoardCell
{
    public int Index { get; private set; }
    public Vector2 ScreenPosition { get; private set; }

    protected Texture2D buyIcone;
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
    }

    public abstract void OnLand(OwnerType currentPlayer);  
    
    public abstract void DrawOnLandUI();
    //Metodo para cuando el player cae en dicha casilla. Permite comprarla o pagar al propietario si no esta ocupada.
    //Si la compra le dan una tarjeta de accion aleatoria
    //Si tiene propietario que salte el evento y le pague
}
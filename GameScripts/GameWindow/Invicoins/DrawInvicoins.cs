using System.Numerics;
using Raylib_cs;

namespace MP_POO_FINAL.GameWindow.Invicoins;

public class DrawInvicoins(int amount) : Invicoins(amount)
{
    private Texture2D[] digits = new Texture2D[10];
    
    private int Hundreds => (Amount / 100) % 10;
    private int Tens => (Amount / 10) % 10;
    private int Units => Amount %10;

    public void LoadNumbers()
    {
        for (int i = 0; i < 10; i++)
        {
            digits[i] = Raylib.LoadTexture($"Sprites/{i}.png");
        }
    }

    public void Draw(int x, int y)
    {
        Raylib.DrawTextureEx(digits[Hundreds],new Vector2(x,y),0,1f,Color.White);
        Raylib.DrawTextureEx(digits[Tens],new Vector2(x+50, y),0,1f,Color.White);
        Raylib.DrawTextureEx(digits[Units],new Vector2(x+100,y),0,1f,Color.White);
    }
}
using System.Numerics;
using Raylib_cs;

namespace MP_POO_FINAL.GameScripts.GameWindow.UI_s;

public class StartRollUI
{
    public void RollStart(Texture2D diceIcone)
    {
        Raylib.DrawRectangle(435, 300, 1100, 100, Color.Black);
        Raylib.DrawText("ROLL TO SEE WHO STARTS", 450, 320, 75, Color.White);
        Raylib.DrawTextureEx(diceIcone, new Vector2(660, 450), 0, 0.7f, Color.White);
    }
}
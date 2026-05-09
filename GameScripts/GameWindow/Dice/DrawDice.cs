using System.Numerics;
using Raylib_cs;

namespace MP_POO_FINAL.GameWindow.Dice;

public class DrawDice
{
    private Texture2D[] numbers = new Texture2D[6];
    
    public void LoadDiceNumbers()
    {
        for (int i = 0; i < 6; i++)
        {
            numbers[i] = Raylib.LoadTexture($"Sprites/dado{i+1}.png");
        }
    }
    
    public void Draw(int number)
    {
        if (number < 1)
        {
            return;
        }
        Raylib.DrawTextureEx(numbers[number - 1], new Vector2(660, 340), 0, 1f, Color.White);
    }
}
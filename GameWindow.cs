using System.Numerics;
using Raylib_cs;

namespace MP_POO_FINAL;

public class GameWindow
{
    //Posiciones tablero
    //1. (455,1050) r: -90;
    //2. (1500,1050) r:-180;
    //3. (1500,30) r:-270
    //4. (455,30) r: 0
    
    private int width = 1920;
    private int height = 1080;
    
    private Texture2D boardTexture;

    public void InitWindowRaylib()
    {
        Raylib.InitWindow(width, height, "Mi Juego en Raylib");

        // Cargar imagen una sola vez
        Texture2D board = Raylib.LoadTexture("Sprites/TABLERO_MONOPOLY.png");
        Texture2D background = Raylib.LoadTexture("Sprites/casino_background.png");
        Texture2D cardIcone = Raylib.LoadTexture("Sprites/CardIcone.png");
        Texture2D diceIcone = Raylib.LoadTexture("Sprites/DiceIcone.png");
        
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(color:Color.White);
            Raylib.DrawTextureEx(background,new Vector2(0,0),0f,1.3f,Color.White);
            Raylib.DrawTextureEx(board, new Vector2 (455,1050), -90, 4f, Color.White);
            Raylib.DrawTextureEx(diceIcone, new Vector2 (80, 850), 0, 0.3f, Color.White);
            Raylib.DrawTextureEx(cardIcone, new Vector2(1620,800), 0f, 0.2f, Color.White);
            // Raylib.DrawText("Dani me cago en todo tio",0,0,20,color:Color.Black);
            Raylib.EndDrawing();
        }
        Raylib.CloseWindow();
    }
}

using System.Numerics;
using Raylib_cs;

namespace MP_POO_FINAL;

public class GameUI
{
    private Texture2D board;
    private Texture2D background;
    private Texture2D cardIcone;
    private Texture2D diceIcone;
    private string diceText = "TIRAR";
    private string inventoryText = "INVENTARIO";

    public Button diceButton = new Button(116, 1010, 200, 50);
    public Button inventoryButton = new Button(800, 1010, 200, 50);
    
    public void LoadAssets()
    {
        board = Raylib.LoadTexture("Sprites/TABLERO_MONOPOLY.png");
        background = Raylib.LoadTexture("Sprites/casino_background.png");
        cardIcone = Raylib.LoadTexture("Sprites/CardIcone.png");
        diceIcone = Raylib.LoadTexture("Sprites/DiceIcone.png");
    }

    public void LoadWindowInfo()
    {
        Raylib.ClearBackground(Color.White);
        Raylib.DrawTextureEx(background, new Vector2(0,0), 0f, 1.3f, Color.White);
        Raylib.DrawTextureEx(board, new Vector2(455,1050), -90, 4f, Color.White);
        Raylib.DrawTextureEx(diceIcone, new Vector2(80,850), 0, 0.3f, Color.White);
        Raylib.DrawText(diceText,130,1010,50,Color.White);
        Raylib.DrawTextureEx(cardIcone, new Vector2(1600,800), 0f, 0.2f, Color.White);
        Raylib.DrawText(inventoryText,1540,1010,50,Color.White);
    }

    public void RotateBoard()
    {
        //Dependiendo de la casilla en la que se encuentre el player el tablero rotará en el sentido horario
    }
}


//Posiciones tablero
//1. (455,1050) r: -90;
//2. (1500,1050) r:-180;
//3. (1500,30) r:-270
//4. (455,30) r: 0

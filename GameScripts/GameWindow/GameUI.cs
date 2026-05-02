using System.Numerics;
using MP_POO_FINAL.GameScripts.GameWindow.Buttons;
using Raylib_cs;

namespace MP_POO_FINAL.GameScripts.GameWindow;

public class GameUI
{
    
    DrawInvicoins drawInvicoins =  new DrawInvicoins(100);
    
    private Texture2D board;
    private Texture2D background;
    private Texture2D cardIcone;
    private Texture2D diceIcone;
    private Texture2D playerIcone;
    private Texture2D Ai1Icone;
    private Texture2D Ai2Icone;
    
    private string diceText = "TIRAR";
    private string inventoryText = "INVENTARIO";

    public Button diceButton = new Button(116, 1010, 200, 50);
    public Button inventoryButton = new Button(1600, 1010, 200, 50);
    
    public void LoadAssets()
    {
        board = Raylib.LoadTexture("Sprites/TABLERO_MONOPOLY.png");
        background = Raylib.LoadTexture("Sprites/casino_background.png");
        
        playerIcone = Raylib.LoadTexture("Sprites/player.png");
        Ai1Icone = Raylib.LoadTexture("Sprites/Ai1.png");
        Ai2Icone = Raylib.LoadTexture("Sprites/Ai2.png");
        
        drawInvicoins.LoadNumbers();
        //cardIcone = Raylib.LoadTexture("Sprites/CardIcone.png");
        //diceIcone = Raylib.LoadTexture("Sprites/DiceIcone.png");
    }

    public void LoadWindowInfo()
    {
        //Raylib.DrawTextureEx(diceIcone, new Vector2(80,850), 0, 0.3f, Color.White);
        //Raylib.DrawText(diceText,130,1010,50,Color.White);
        //Raylib.DrawTextureEx(cardIcone, new Vector2(1600,800), 0f, 0.2f, Color.White);
        //Raylib.DrawText(inventoryText,1540,1010,50,Color.White);
    }

    public void LoadEssentials()
    {
        Raylib.ClearBackground(Color.White);
        Raylib.DrawTextureEx(background, new Vector2(0,0), 0f, 1.3f, Color.White);
        Raylib.DrawTextureEx(board, new Vector2(480,1050), -90, 4f, Color.White);
        
        Raylib.DrawTextureEx(playerIcone, new Vector2(-30, 0), 0, 0.2f, Color.White);
        Raylib.DrawTextureEx(Ai1Icone, new Vector2(-30, 160), 0, 0.2f, Color.White);
        Raylib.DrawTextureEx(Ai2Icone, new Vector2(-30, 320), 0, 0.2f, Color.White);
    }
}


//Posiciones tablero
//1. (455,1050) r: -90;
//2. (1500,1050) r:-180;
//3. (1500,30) r:-270
//4. (455,30) r: 0

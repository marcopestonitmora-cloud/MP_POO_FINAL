using System.Numerics;
using MP_POO_FINAL.GameWindow.BoardInfo;
using MP_POO_FINAL.GameWindow.Buttons;
using MP_POO_FINAL.GameWindow.Characters;
using MP_POO_FINAL.GameWindow.Invicoins;
using Raylib_cs;

namespace MP_POO_FINAL.GameWindow.UI_s;

public class GameUi
{
    private Player player;
    private AI ai1;
    private AI ai2;

    public GameUi(Player player, AI ai1, AI ai2)
    {
        this.player = player;
        this.ai1    = ai1;
        this.ai2    = ai2;
    }
    
    private Texture2D board;
    private Texture2D background;
    public Texture2D diceIcone;
    private Texture2D playerIcone;
    private Texture2D ai1Icone;
    private Texture2D ai2Icone;
    private Texture2D cardIcone;

    private Texture2D playerToken;
    private Texture2D _ai1Token;
    private Texture2D _ai2Token;

    public Button diceButton = new Button(116, 1010, 200, 50);
    public Button inventoryButton = new Button(1600, 1010, 200, 50);
    public Button startDiceRollButton = new Button(600, 450, 400, 400);
    
    public void LoadAssets()
    {
        board = Raylib.LoadTexture("Sprites/TABLERO_MONOPOLY.png");
        background = Raylib.LoadTexture("Sprites/casino_background.png");
        
        playerIcone = Raylib.LoadTexture("Sprites/player.png");
        ai1Icone = Raylib.LoadTexture("Sprites/Ai1.png");
        ai2Icone = Raylib.LoadTexture("Sprites/Ai2.png");
        
        cardIcone = Raylib.LoadTexture("Sprites/CardIcone.png");
        diceIcone = Raylib.LoadTexture("Sprites/DiceIcone.png");
        
        playerToken = Raylib.LoadTexture("Sprites/playerToken.png");
    }

    public void DrawEssentials()
    {
        Raylib.ClearBackground(Color.White);
        Raylib.DrawTextureEx(background, new Vector2(0,0), 0f, 1.3f, Color.White);
        Raylib.DrawTextureEx(board, new Vector2(480,1050), -90, 4f, Color.White);
        
        Raylib.DrawTextureEx(playerIcone, new Vector2(-30, 0), 0, 0.2f, Color.White);
        Raylib.DrawTextureEx(ai1Icone, new Vector2(-30, 160), 0, 0.2f, Color.White);
        Raylib.DrawTextureEx(ai2Icone, new Vector2(-30, 320), 0, 0.2f, Color.White);
        
        Raylib.DrawTextureEx(playerToken, new Vector2(player.ScreenPosition.X,player.ScreenPosition.Y), 0, 0.15f, Color.White);
        
        player.Coins.Draw(120,80);
        ai1.Coins.Draw(120,240);
        ai2.Coins.Draw(120,400);
    }
}


//Posiciones tablero
//1. (455,1050) r: -90;
//2. (1500,1050) r:-180;
//3. (1500,30) r:-270;
//4. (455,30) r: 0;

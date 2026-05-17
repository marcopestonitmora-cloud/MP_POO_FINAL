using System.Numerics;
using MP_POO_FINAL.GameWindow.BoardInfo;
using MP_POO_FINAL.GameWindow.Buttons;
using MP_POO_FINAL.GameWindow.Characters;
using Raylib_cs;

namespace MP_POO_FINAL.GameWindow.UI_s;
public class GameUi
{
    private Board board;
    private Player Player;
    private AI Ai1;
    private AI Ai2;

    public GameUi(Player player, AI ai1, AI ai2)
    {
        this.Player = player;
        this.Ai1    = ai1;
        this.Ai2    = ai2;
        this.board =  board;
    }
    
    private Texture2D inviBoard;
    public Texture2D background;
    private Texture2D playerIcone;
    private Texture2D ai1Icone;
    private Texture2D ai2Icone;
    public Texture2D diceIcone;
    public Texture2D cardIcone;
    
    public Texture2D infoIcone;
    public Texture2D endTurnIcone;

    private Texture2D playerToken;
    private Texture2D ai1Token;
    private Texture2D ai2Token;

    public Button diceButton = new Button(116, 1010, 200, 50);
    public Button inventoryButton = new Button(1600, 1010, 200, 50);
    public Button startDiceRollButton = new Button(600, 450, 400, 400);

    private bool alreadyPrinted = false;
    
    public void LoadAssets()
    {
        inviBoard = Raylib.LoadTexture("Sprites/TABLERO_MONOPOLY.png");
        background = Raylib.LoadTexture("Sprites/casino_background.png");
        
        playerIcone = Raylib.LoadTexture("Sprites/player.png");
        ai1Icone = Raylib.LoadTexture("Sprites/Ai1.png");
        ai2Icone = Raylib.LoadTexture("Sprites/Ai2.png");
        
        cardIcone = Raylib.LoadTexture("Sprites/CardIcone.png");
        diceIcone = Raylib.LoadTexture("Sprites/DiceIcone.png");
        
        playerToken = Raylib.LoadTexture("Sprites/playerToken.png");
        ai1Token = Raylib.LoadTexture("Sprites/A1Token.png");
        ai2Token = Raylib.LoadTexture("Sprites/A2Token.png");
        
        cardIcone = Raylib.LoadTexture("Sprites/CardIcone.png");
        diceIcone = Raylib.LoadTexture("Sprites/DiceIcone.png");
        
        infoIcone = Raylib.LoadTexture("Sprites/InfoIcone.png");
        endTurnIcone = Raylib.LoadTexture("Sprites/EndTurnIcone.png");
    }

    public void DrawEssentials()
    {
        Raylib.ClearBackground(Color.White);
        Raylib.DrawTextureEx(background, new Vector2(0,0), 0f, 1.3f, Color.White);
        Raylib.DrawTextureEx(inviBoard, new Vector2(480,1050), -90, 4f, Color.White);
        
        Raylib.DrawTextureEx(playerIcone, new Vector2(-30, 0), 0, 0.2f, Color.White);
        Raylib.DrawTextureEx(ai1Icone, new Vector2(-30, 160), 0, 0.2f, Color.White);
        Raylib.DrawTextureEx(ai2Icone, new Vector2(-30, 320), 0, 0.2f, Color.White);
        
        Raylib.DrawTextureEx(playerToken, new Vector2(Player.ScreenPosition.X - 20,Player.ScreenPosition.Y-5), 0, 0.15f, Color.White);
        Raylib.DrawTextureEx(ai1Token, new Vector2((Ai1.ScreenPosition.X + 20),Ai1.ScreenPosition.Y - 9), 0, 0.08f, Color.White);
        Raylib.DrawTextureEx(ai2Token, new Vector2((Ai2.ScreenPosition.X + 0),Ai2.ScreenPosition.Y + 32), 0, 0.08f, Color.White);
        
        Player.Coins.Draw(120,80);
        Ai1.Coins.Draw(120,240);
        Ai2.Coins.Draw(120,400);
    }
}


using MP_POO_FINAL.GameWindow.BoardInfo;
using MP_POO_FINAL.GameWindow.Buttons;
using MP_POO_FINAL.GameWindow.Characters;
using MP_POO_FINAL.GameWindow.Screens;
using Raylib_cs;

namespace MP_POO_FINAL.GameWindow;

public class GameWindow
{
    private MouseTracker mouse = new MouseTracker();
    private ButtonsLogic buttonLogic = new ButtonsLogic();
    private Board board;
    private Player player;
    private AI ai1;
    private AI ai2;
    
    private IScreen currentScreen;
    
    private StartScreen startScreen = new StartScreen();
    private GameScreen gameScreen;

    public void Run()
    {
        board  = BoardFactory.CreateBoard();
        player = new Player(500,OwnerType.Player);
        ai1 = new AI(500,OwnerType.Ai1);
        ai2 = new AI(500, OwnerType.Ai2);
        gameScreen =  new GameScreen(player,ai1,ai2);
        
        Raylib.InitWindow(1920, 1080, "Monopoly");
        
        player.Coins.LoadNumbers();
        ai1.Coins.LoadNumbers();
        ai2.Coins.LoadNumbers();
        
        startScreen.LoadAssets();
        gameScreen.LoadAssets();
        
        player.Move(0, board); 
        
        currentScreen = startScreen;

        while (!Raylib.WindowShouldClose())
        {
            mouse.MouseTrack();
            currentScreen.Update(mouse, buttonLogic, player, board);

            if (startScreen.NextState == GameState.InGame)
            {
                currentScreen = gameScreen;
            }

            Raylib.BeginDrawing();
            currentScreen.Draw();
            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}
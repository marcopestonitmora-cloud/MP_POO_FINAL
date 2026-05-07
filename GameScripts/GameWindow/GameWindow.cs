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
    private Player player = new Player(500,OwnerType.Player);
    public AI ai1 = new AI(500, OwnerType.Ai1);
    public AI ai2 = new AI(500, OwnerType.Ai2);
    private Board board = BoardFactory.CreateBoard();
    
    private IScreen currentScreen;
    
    private StartScreen startScreen = new StartScreen();
    private GameScreen gameScreen = new GameScreen();
    
    private GameEvents.GameEvents gameEvents = new GameEvents.GameEvents();

    public void Run()
    {
        Raylib.InitWindow(1920, 1080, "Monopoly");
        
        startScreen.LoadAssets();
        gameScreen.LoadAssets();
        
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
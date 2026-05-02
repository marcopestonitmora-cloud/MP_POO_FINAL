using MP_POO_FINAL.GameScripts.GameWindow.Buttons;
using Raylib_cs;

namespace MP_POO_FINAL.GameScripts.GameWindow;

public class GameWindow
{
    private MouseTracker mouse = new MouseTracker();
    private ButtonsLogic buttonLogic = new ButtonsLogic();
    private IScreen currentScreen;
    private StartScreen startScreen = new StartScreen();
    private GameScreen gameScreen = new GameScreen();

    public void Run()
    {
        Raylib.InitWindow(1920, 1080, "Monopoly");
        startScreen.LoadAssets();
        gameScreen.LoadAssets();
        
        currentScreen = startScreen;

        while (!Raylib.WindowShouldClose())
        {
            mouse.MouseTrack();
            currentScreen.Update(mouse, buttonLogic);

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
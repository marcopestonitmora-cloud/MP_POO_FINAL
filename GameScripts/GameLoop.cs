using MP_POO_FINAL.GameScripts.GameWindow;

namespace MP_POO_FINAL;

public class GameLoop
{
    private bool startDiceRool = false;
    
    public void Loop()
    {
        GameWindow gameWindow = new GameWindow();
        gameWindow.Run();
    }
}
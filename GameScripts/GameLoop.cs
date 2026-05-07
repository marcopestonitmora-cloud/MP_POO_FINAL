namespace MP_POO_FINAL;

public class GameLoop
{
    private bool startDiceRool = false;
    
    public void Loop()
    {
        GameWindow.GameWindow gameWindow = new GameWindow.GameWindow();
        gameWindow.Run();
    }
}
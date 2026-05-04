using Raylib_cs;

namespace MP_POO_FINAL.GameScripts.GameWindow.UI_s;

public class AiTurnUI
{
    StartRollEvent startRollEvent = new StartRollEvent();
    
    public void DrawAiUI()
    {
        if (startRollEvent.StarterIndex == 0)
        {
            Raylib.DrawRectangle(1525, 50, 320, 70, Color.Black);
            Raylib.DrawText("Turn: Ai1",1530,50,70,Color.Red);
        }
        else if (startRollEvent.StarterIndex == 1)
        {
            Raylib.DrawRectangle(1535, 50, 320, 70, Color.Black);
            Raylib.DrawText("Turn: Ai2",1530,50,70,Color.Red);
        }
    }
}
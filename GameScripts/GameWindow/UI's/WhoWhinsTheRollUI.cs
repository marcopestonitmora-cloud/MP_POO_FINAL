using MP_POO_FINAL.GameScripts.Managers;
using Raylib_cs;

namespace MP_POO_FINAL.GameScripts.GameWindow.UI_s;

public class WhoWinsTheRollUi
{
    private GameEvents GameEvents => GameManagers.Instance.GameEvents;
    private readonly Color _player = Color.Blue;
    private readonly Color _ai = Color.Red;
    public void DrawRollWinner()
    {
        for (int i = 0; i < GameEvents.startRollEvent.Throwers.Length; i++)
        {
            string text = $"{GameEvents.startRollEvent.Throwers[i]}: {GameEvents.startRollEvent.DiceNumber[i]}";
            int textWidth = Raylib.MeasureText(text, 75);

            if(i != 2)
            {
                Raylib.DrawRectangle(475 + (350 * i), 300, textWidth + 10, 70, Color.Black);
                Raylib.DrawText(text, 480 + (350 * i), 300, 75,_ai);
            }
            else
            {
                Raylib.DrawRectangle(475 + (350 * i), 300, textWidth + 10, 70, Color.Black);
                Raylib.DrawText(text, 480 + (350 * i), 300, 75,_player);
            }
        }
    
        string winnerText = $"{GameEvents.startRollEvent.Throwers[GameEvents.startRollEvent.StarterIndex]} starts";
        int winnerWidth = Raylib.MeasureText(winnerText, 135);

        if (GameEvents.startRollEvent.Throwers[GameEvents.startRollEvent.StarterIndex] == "Player")
        {
            Raylib.DrawRectangle(505, 505, winnerWidth + 10, 140, Color.Black);
            Raylib.DrawText(winnerText, 510, 510, 135, _player);   
        }
        else
        {
            Raylib.DrawRectangle(645, 505, winnerWidth + 10, 140, Color.Black);
            Raylib.DrawText(winnerText, 650, 510, 135, _ai);   
        }
    }
}
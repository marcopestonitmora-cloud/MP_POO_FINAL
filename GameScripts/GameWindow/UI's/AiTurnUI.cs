using MP_POO_FINAL.GameWindow.Dice;
using MP_POO_FINAL.Managers;
using Raylib_cs;

namespace MP_POO_FINAL.GameWindow.UI_s;

public class AiTurnUi
{
    private DiceRoll diceRoll => EventManager.Instance.GameEvents.diceRoll;
    private DrawDice diceNumbers;
    
    public AiTurnUi(DrawDice diceNumbers)
    {
        this.diceNumbers = diceNumbers;
    }
    
    public void DrawAiUi()
    {
        if (EventManager.Instance.CurrentTurn == 0)
        {
            Raylib.DrawRectangle(1525, 50, 320, 70, Color.Black);
            Raylib.DrawText("Turn: Ai1", 1530, 50, 70, Color.Red);
        }
        else if (EventManager.Instance.CurrentTurn == 1)
        {
            Raylib.DrawRectangle(1535, 50, 320, 70, Color.Black);
            Raylib.DrawText("Turn: Ai2", 1530, 50, 70, Color.Red);
        }
        
        if (diceRoll.HasRolled)
        {
            diceNumbers.Draw(diceRoll.Number);
        }
    }
}
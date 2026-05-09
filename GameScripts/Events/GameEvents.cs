using MP_POO_FINAL.Events;
using MP_POO_FINAL.GameWindow.Dice;

namespace MP_POO_FINAL.GameScripts.Events;

public class GameEvents
{
    public StartRollEvent startRollEvent = new StartRollEvent();
    public AiEvents aiEvents = new AiEvents();
    public DiceRoll diceRoll = new DiceRoll();
}
using MP_POO_FINAL.GameScripts.GameWindow;

namespace MP_POO_FINAL.GameScripts;

public class GameEvents
{
    private DiceRoll roll = new DiceRoll();
    private string[] throwers = {"Player","Ai1","Ai2"};
    private int[] diceNumber = new int[3];
    public GameUI ui;
    
    public event Action OnStartRollEnd;

    private int StarterIndex { get; set;}

    public async Task StartDiceRoll()
    {
        for (int i = 0; i < 3; i++)
        {
            diceNumber[i] = roll.RollTheDice();
            Console.WriteLine($"{throwers[i]} ha sacado {diceNumber[i]}");
        }
        
        StarterIndex = GetHighest();
        ui.rollStart = true;
        Console.WriteLine($"Empieza {throwers[StarterIndex]}");
        await Task.Delay(1000);
        OnStartRollEnd?.Invoke();
    }

    private int GetHighest()
    {
        int index = 0;
        for (int i = 1; i < diceNumber.Length; i++)
        {
            if (diceNumber[i] > diceNumber[index])
            {
                index = i;
            }
        }
        return index;
    }
}
using MP_POO_FINAL.GameScripts.GameWindow.Dice;

namespace MP_POO_FINAL.GameScripts.GameEvents;

public class StartRollEvent
{
    private DiceRoll roll = new DiceRoll();
    private string[] throwers = {"Ai1","Ai2","Player"};
    private int[] diceNumber = new int[3];
    
    //Expongo los datos como variables publicas para poder llamarlos desde el gameUI
    public string[] Throwers => throwers;
    public int[] DiceNumber => diceNumber;
    public int StarterIndex { get; set;}
    
    public bool HasRolled { get; private set; } = false;
    
    public event Action OnStartRollEnd;
    public event Action OnPlayerWins;
    public event Action OnAi1Wins;
    public event Action OnAi2Wins;


    public async Task StartDiceRoll()
    {
        for (int i = 0; i < throwers.Length; i++)
        {
            diceNumber[i] = roll.RollTheDice();
            Console.WriteLine($"{throwers[i]} ha sacado {diceNumber[i]}");
        }
        
        StarterIndex = GetHighest();
        Console.WriteLine($"Empieza {throwers[StarterIndex]}");
        
        
        HasRolled = true;
        
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

    public async Task WhoWinsTheRoll()
    {
        await Task.Delay(3000);

        if (throwers[StarterIndex] == "Player")
        {
            OnPlayerWins?.Invoke();
        }
        else if (throwers[StarterIndex] == "Ai1")
        {
            OnAi1Wins?.Invoke();
        }
        else if (throwers[StarterIndex] == "Ai2")
        {
            OnAi2Wins?.Invoke();
        }
    }
}
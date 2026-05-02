namespace MP_POO_FINAL.GameScripts;

public class GameEvents
{
    private DiceRoll roll = new DiceRoll();
    private string[] throwers = {"Player","Ai1","Ai2"};
    private int[] diceNumber = new int[3];

    protected int StarterIndex { get; private set;}

    public void StartDiceRoll()
    {
        for (int i = 0; i < 3; i++)
        {
            diceNumber[i] = roll.RollTheDice();
            Console.WriteLine($"{throwers[i]} ha sacado {diceNumber[i]}");
        }

        StarterIndex = GetHighest();
        Console.WriteLine($"Empieza {throwers[StarterIndex]}");
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
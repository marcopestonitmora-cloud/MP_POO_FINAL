using System.Diagnostics;

namespace MP_POO_FINAL.GameScripts;

public class DiceRoll
{
    public void RollTheDice()
    {
        Random random = new Random();
        
        int numero = random.Next(1,7); 
        
        Console.WriteLine(numero);
    }
}
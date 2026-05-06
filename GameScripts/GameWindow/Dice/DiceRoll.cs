namespace MP_POO_FINAL.GameScripts.GameWindow.Dice;

public class DiceRoll
{
    public int RollTheDice()
    {
        Random random = new Random();
        
        int numero = random.Next(1,7); 
        
        Console.WriteLine(numero);
        
        return numero;
    }
}
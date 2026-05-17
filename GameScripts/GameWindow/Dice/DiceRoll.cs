using MP_POO_FINAL.Managers;

namespace MP_POO_FINAL.GameWindow.Dice;

public class DiceRoll
{
    public int Number { get; private set; } = 0;
    public bool HasRolled { get; private set; } = false;

    public int RollTheDice()
    {
        Random random = new Random();
        Number = random.Next(1, 7);
        HasRolled = true;
        
        return Number;
    }
    
    //Evita que aparezca la imagen del dado obtenido en el turno anterior
    public void Reset()
    {
        Number = 0;
        HasRolled = false;
    }
}
namespace MP_POO_FINAL.GameScripts.GameWindow.Buttons;

public class ButtonsLogic
{
    DiceRoll diceRoll =  new DiceRoll();
    GameEvents gameEvents = new GameEvents();
    
    public void DiceButton(Button playButton, MouseTracker mouse)
    {
        playButton.Update(mouse);

        if (playButton.IsClicked())
        {
            diceRoll.RollTheDice();
            Console.WriteLine("Boton presionado!");
        }
    }

    public void InventoryButton(Button inventoryButton, MouseTracker mouse)
    {
        inventoryButton.Update(mouse);

        if (inventoryButton.IsClicked()) //Añadir && Tu turno, que solo puedas pulsarlo si es tu turno
        {
            Console.WriteLine("PUTA vigo!");
        }
    }

    public bool PlayButton(Button playButton, MouseTracker mouse)
    {
        playButton.Update(mouse);
        return playButton.IsClicked();
    }

    public void StartDiceRollButton(Button startDiceRollButton, MouseTracker mouse)
    {
        startDiceRollButton.Update(mouse);
        if (startDiceRollButton.IsClicked())
        {
            gameEvents.StartDiceRoll();
        }
    }
}
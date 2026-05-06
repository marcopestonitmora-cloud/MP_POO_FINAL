using MP_POO_FINAL.GameScripts.GameWindow.Dice;
using MP_POO_FINAL.GameScripts.Managers;

namespace MP_POO_FINAL.GameScripts.GameWindow.Buttons;

public class ButtonsLogic
{
    DiceRoll diceRoll =  new DiceRoll();
    
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

        if (inventoryButton.IsClicked())
        {
            Console.WriteLine("PUTA vigo!");
        }
    }

    public bool PlayButton(Button playButton, MouseTracker mouse)
    {
        playButton.Update(mouse);
        return playButton.IsClicked();
    }

    public async void StartDiceRollButton(Button button, MouseTracker mouse, GameEvents.GameEvents gameEvents)
    {
        button.Update(mouse);
        if (button.IsClicked())
        {
            await gameEvents.startRollEvent.StartDiceRoll();
        }
    }
}
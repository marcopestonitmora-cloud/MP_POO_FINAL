using MP_POO_FINAL.GameWindow.Dice;
using MP_POO_FINAL.GameWindow.BoardInfo;
using MP_POO_FINAL.GameWindow.Characters;

namespace MP_POO_FINAL.GameWindow.Buttons;

public class ButtonsLogic
{
    readonly DiceRoll diceRoll =  new DiceRoll();
    
    public void DiceButton(Button playButton, MouseTracker mouse, Character player, Board board)
    {
        playButton.Update(mouse);

        if (playButton.IsClicked())
        {
            int steps = diceRoll.RollTheDice();
            player.Move(steps, board);
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

    public async void StartDiceRollButton(Button button, MouseTracker mouse, MP_POO_FINAL.GameEvents.GameEvents gameEvents)
    {
        button.Update(mouse);
        if (button.IsClicked())
        {
            await gameEvents.startRollEvent.StartDiceRoll();
        }
    }
}
using MP_POO_FINAL.Events;
using MP_POO_FINAL.GameScripts.Events;
using MP_POO_FINAL.GameWindow.Dice;
using MP_POO_FINAL.GameWindow.BoardInfo;
using MP_POO_FINAL.GameWindow.Characters;
using MP_POO_FINAL.Managers;

namespace MP_POO_FINAL.GameWindow.Buttons;

public class ButtonsLogic
{
    public event Action OnPlayerTurnEnded;
    public event Action OnBuyProperty;
    private OwnerType owner;
    
    public void DiceButton(Button playButton, MouseTracker mouse, Character player, Board board)
    {
        playButton.Update(mouse);

        if (playButton.IsClicked())
        {
            int steps = EventManager.Instance.GameEvents.diceRoll.RollTheDice();
            player.Move(steps, board);
        }
    }

    public void BuyButton(Button buyButton, MouseTracker mouse)
    {
        buyButton.Update(mouse);
        if (buyButton.IsClicked())
        {
            if (owner == OwnerType.Player)
            {
                return;
            }

            OnBuyProperty?.Invoke();
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

    public void EndTurnButton(Button endTurnButton, MouseTracker mouse)
    {
        endTurnButton.Update(mouse);
        if (endTurnButton.IsClicked())
        {
            OnPlayerTurnEnded?.Invoke();
        }
    }

    public bool PlayButton(Button playButton, MouseTracker mouse)
    {
        playButton.Update(mouse);
        return playButton.IsClicked();
    }

    public async void StartDiceRollButton(Button button, MouseTracker mouse, GameEvents gameEvents)
    {
        button.Update(mouse);
        if (button.IsClicked())
        {
            await gameEvents.startRollEvent.StartDiceRoll();
        }
    }
}
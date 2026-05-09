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
    public event Action OnSellProperty;
    public event Action OnBuyProperty;
    private OwnerType owner;
    private PropertyCell property;
    
    //STARTS THE GAME
    public bool PlayButton(Button playButton, MouseTracker mouse)
    {
        playButton.Update(mouse);
        return playButton.IsClicked();
    }
    
    
    //SAME AS THE ROLL DICE BUT JUST FOR THE INITIAL PART OF THE GAME
    public async void StartDiceRollButton(Button button, MouseTracker mouse, GameEvents gameEvents)
    {
        button.Update(mouse);
        if (button.IsClicked())
        {
            await gameEvents.startRollEvent.StartDiceRoll();
        }
    }
    
    //ROLLS THE DICE 
    public void DiceButton(Button playButton, MouseTracker mouse, Character player, Board board)
    {
        playButton.Update(mouse);

        if (playButton.IsClicked())
        {
            int steps = EventManager.Instance.GameEvents.diceRoll.RollTheDice();
            player.Move(steps, board);
        }
    }

    //IF U LANDO ON A PROPERTY U CAN BUY IT IF U HAVE ENOUGH MONEY
    public void BuyButton(Button buyButton, MouseTracker mouse)
    {
        buyButton.Update(mouse);
        if (buyButton.IsClicked())
        {
            //Actualiza directamente por si compras la casilla y vuelves a pulsar el boton
            property = EventManager.Instance.board.GetCellIndex(EventManager.Instance.player.BoardPosition) as PropertyCell;

            if (property.Owner != OwnerType.None)
            {
                return;
            }

            OnBuyProperty?.Invoke();
        }
    }

    public void SellButton(Button sellButton, MouseTracker mouse)
    {
        sellButton.Update(mouse);
        if (sellButton.IsClicked())
        {
            if (property.Owner != OwnerType.Player)
            {
                return;
            }

            OnSellProperty?.Invoke();
        }
    }

    //LET THE PLAYER SEE HIS ACTION CARDS
    public void InventoryButton(Button inventoryButton, MouseTracker mouse)
    {
        inventoryButton.Update(mouse);

        if (inventoryButton.IsClicked())
        {
            Console.WriteLine("PUTA vigo!");
        }
    }

    //ENDS THE PLAYER ROUND
    public void EndTurnButton(Button endTurnButton, MouseTracker mouse)
    {
        endTurnButton.Update(mouse);
        if (endTurnButton.IsClicked())
        {
            OnPlayerTurnEnded?.Invoke();
        }
    }
}
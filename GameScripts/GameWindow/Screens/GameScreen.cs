using MP_POO_FINAL.GameScripts.GameWindow.Buttons;
using Raylib_cs;

namespace MP_POO_FINAL.GameScripts.GameWindow;

public class GameScreen : IScreen
{   
    GameUI gameUi = new GameUI();
    
    public void LoadAssets() =>  gameUi.LoadAssets();

    public void Update(MouseTracker mouse, ButtonsLogic buttonLogic)
    {
        buttonLogic.DiceButton(gameUi.diceButton, mouse);
        buttonLogic.InventoryButton(gameUi.inventoryButton, mouse);
        buttonLogic.StartDiceRollButton(gameUi.startDiceRollButton, mouse);
    }

    public void Draw() => gameUi.LoadEssentials();
}




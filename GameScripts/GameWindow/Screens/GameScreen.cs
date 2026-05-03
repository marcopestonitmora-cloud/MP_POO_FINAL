using MP_POO_FINAL.GameScripts.GameWindow.Buttons;
using MP_POO_FINAL.GameScripts.Managers;
using Raylib_cs;

namespace MP_POO_FINAL.GameScripts.GameWindow;

public class GameScreen : IScreen
{   
    GameUI gameUi = new GameUI();
    
    public void LoadAssets() =>  gameUi.LoadAssets();

    public void Update(MouseTracker mouse, ButtonsLogic buttonLogic)
    {
        switch (GameManagers.Instance.Phase)
        {
            case GamePhase.RollToStart:
                buttonLogic.StartDiceRollButton(gameUi.startDiceRollButton, mouse);
                break;
            case GamePhase.Playing:
                buttonLogic.DiceButton(gameUi.diceButton, mouse);
                buttonLogic.InventoryButton(gameUi.inventoryButton, mouse);
                break;
        }
    }

    public void Draw() => gameUi.SceneChange();
}




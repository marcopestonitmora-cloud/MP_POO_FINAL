using MP_POO_FINAL.GameScripts.GameWindow.Buttons;
using MP_POO_FINAL.GameScripts.Managers;
using Raylib_cs;

namespace MP_POO_FINAL.GameScripts.GameWindow;

public class GameScreen : IScreen
{   
    GameUI gameUi = new GameUI();
    private PhaseLogic phaseLogic;
    
    public GameScreen()
    {
        phaseLogic = new PhaseLogic(gameUi);
    }
    
    public void LoadAssets() =>  gameUi.LoadAssets();

    public void Update(MouseTracker mouse, ButtonsLogic buttonLogic)
    {
        switch (EventManager.Instance.Phase)
        {
            case GamePhase.RollToStart:
                buttonLogic.StartDiceRollButton(gameUi.startDiceRollButton, mouse, EventManager.Instance.GameEvents);
                break;
            case GamePhase.Playing:
                buttonLogic.DiceButton(gameUi.diceButton, mouse);
                buttonLogic.InventoryButton(gameUi.inventoryButton, mouse);
                break;
        }
    }

    public void Draw() => phaseLogic.SceneChange();
}




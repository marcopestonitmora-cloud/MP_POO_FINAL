using MP_POO_FINAL.GameWindow.BoardInfo;
using MP_POO_FINAL.GameWindow.Buttons;
using MP_POO_FINAL.GameWindow.Characters;
using MP_POO_FINAL.Managers;
using MP_POO_FINAL.GameWindow.UI_s;

namespace MP_POO_FINAL.GameWindow.Screens;

public class GameScreen : IScreen
{   
    GameUi gameUi = new GameUi();
    private PhaseLogic phaseLogic;
    
    public GameScreen()
    {
        phaseLogic = new PhaseLogic(gameUi);
    }
    
    public void LoadAssets() =>  gameUi.LoadAssets();

    public void Update(MouseTracker mouse, ButtonsLogic buttonLogic, Character character, Board board)
    {
        switch (EventManager.Instance.Phase)
        {
            case GamePhase.RollToStart:
                buttonLogic.StartDiceRollButton(gameUi.startDiceRollButton, mouse, EventManager.Instance.GameEvents);
                break;
            case GamePhase.Playing:
                buttonLogic.DiceButton(gameUi.diceButton, mouse, character, board);
                buttonLogic.InventoryButton(gameUi.inventoryButton, mouse);
                break;
        }
    }

    public void Draw() => phaseLogic.SceneChange();
}




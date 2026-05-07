using MP_POO_FINAL.GameWindow.BoardInfo;
using MP_POO_FINAL.GameWindow.Buttons;
using MP_POO_FINAL.GameWindow.Characters;
using MP_POO_FINAL.Managers;
using MP_POO_FINAL.GameWindow.UI_s;

namespace MP_POO_FINAL.GameWindow.Screens;

public class GameScreen : IScreen
{   
    private Player player;
    private AI ai1;
    private AI ai2;
    
    private PhaseLogic phaseLogic;
    private GameUi gameUi;
    
    public GameScreen(Player player, AI ai1, AI ai2)
    {
        this.player = player;
        this.ai1    = ai1;
        this.ai2    = ai2;
        gameUi      = new GameUi(player, ai1, ai2); // asigna el campo, no una variable local
        phaseLogic  = new PhaseLogic(gameUi);
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




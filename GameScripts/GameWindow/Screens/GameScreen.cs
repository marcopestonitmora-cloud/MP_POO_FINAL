using MP_POO_FINAL.GameWindow.BoardInfo;
using MP_POO_FINAL.GameWindow.Buttons;
using MP_POO_FINAL.GameWindow.Characters;
using MP_POO_FINAL.GameWindow.Dice;
using MP_POO_FINAL.Managers;
using MP_POO_FINAL.GameWindow.UI_s;

namespace MP_POO_FINAL.GameWindow.Screens;

public class GameScreen : IScreen
{   
    private Player _player;
    private AI _ai1;
    private AI _ai2;
    private DrawDice diceNumbers;
    
    private PhaseLogic phaseLogic;
    private GameUi gameUi;
    private OnLandTurnUi onLandTurnUI;
    private PlayerTurnUI playerUI;
    private InventoryUI inventoryUI;
    
    public GameScreen(Player player, AI ai1, AI ai2, DrawDice diceNumbers, Board board)
    {
        _player = player;
        _ai1    = ai1;
        _ai2    = ai2;
        this.diceNumbers = diceNumbers;
        gameUi      = new GameUi(player, ai1, ai2);
        playerUI = new PlayerTurnUI(diceNumbers, gameUi);
        onLandTurnUI = new OnLandTurnUi(gameUi);
        inventoryUI = new InventoryUI(gameUi);
        phaseLogic  = new PhaseLogic(gameUi, diceNumbers, ai1, ai2,  board);
    }

    public void LoadAssets() => gameUi.LoadAssets();
    public void Update(MouseTracker mouse, ButtonsLogic buttonLogic, Character player, Character ai1, Character ai2, Board board)
    {
        switch (EventManager.Instance.Phase)
        {
            case GamePhase.RollToStart:
            {
                buttonLogic.StartDiceRollButton(gameUi.startDiceRollButton, mouse, EventManager.Instance.GameEvents);
                break;
            }
            case GamePhase.Playing:
            {
                buttonLogic.DiceButton(gameUi.diceButton, mouse,player,board);
                buttonLogic.InventoryButton(gameUi.inventoryButton, mouse);
                break;
            }
            case GamePhase.OnLandTurn:
            {
                buttonLogic.EndTurnButton(onLandTurnUI.endTurnButton, mouse);
                buttonLogic.BuyButton(onLandTurnUI.buyButton, mouse);
                buttonLogic.SellButton(onLandTurnUI.sellButton, mouse);
                break;
            }
            case GamePhase.Inventory:
            {
                buttonLogic.ExitInventoryButton(inventoryUI.exitButton,mouse);
                break;
            }
        }
    }

    public void Draw() => phaseLogic.SceneChange();
}




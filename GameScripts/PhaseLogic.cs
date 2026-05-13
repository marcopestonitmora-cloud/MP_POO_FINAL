using MP_POO_FINAL.GameWindow.BoardInfo;
using MP_POO_FINAL.GameWindow.Characters;
using MP_POO_FINAL.GameWindow.Dice;
using MP_POO_FINAL.GameWindow.UI_s;
using MP_POO_FINAL.Managers;

namespace MP_POO_FINAL;

public class PhaseLogic
{
    private DrawDice diceNumbers;
    
    private EventManager eventManager = EventManager.Instance;
    
    private WhoWinsTheRollUi rollWinnerUI = new WhoWinsTheRollUi();
    private StartRollUI startRollUI = new StartRollUI();
    private AiLogic aiLogic;

    private OnLandTurnUi onLandTurnUI;
    private AiTurnUi aiTurnUI;
    private PlayerTurnUI playerUI;
    private GameUi gameUI;
    private PropetiesUI propetiesUI;

    private AI ai1;
    private AI ai2;
    private Board board;
    
    private GamePhase lastPhase =  GamePhase.RollToStart;

    private bool aiTurnStarted = false;

    public PhaseLogic(GameUi gameUi, DrawDice diceNumbers,AI ai1, AI ai2, Board board)
    {
        gameUI = gameUi;
        this.diceNumbers = diceNumbers;
        this.ai1 = ai1;
        this.ai2 = ai2;
        this.board = board;
        
        aiTurnUI = new AiTurnUi(diceNumbers);
        playerUI = new PlayerTurnUI(diceNumbers,gameUi);
        onLandTurnUI = new OnLandTurnUi(gameUi);
        propetiesUI = new PropetiesUI(board);
        aiLogic = new AiLogic(ai1, ai2, board);
    }

    public void SceneChange()
    {
        if (EventManager.Instance.Phase != lastPhase)
        {
            aiTurnStarted = false;
            lastPhase = EventManager.Instance.Phase;
        }

        switch (EventManager.Instance.Phase)
        {
            case GamePhase.RollToStart:
            {
                gameUI.DrawEssentials();
                startRollUI.RollStart(gameUI.diceIcone);
                break;
            }
            case GamePhase.WhoWinsTheRoll:
            {
                gameUI.DrawEssentials();
                rollWinnerUI.DrawRollWinner();
                break;
            }
            case GamePhase.Playing:
            {
                gameUI.DrawEssentials();
                propetiesUI.DrawPropetiesUI();
                playerUI.DrawPlayerUI();
                break;
            }
            case GamePhase.Ai1Turn:
            {
                gameUI.DrawEssentials();
                propetiesUI.DrawPropetiesUI();
                aiTurnUI.DrawAiUi();
                if (!aiTurnStarted)
                {
                    aiTurnStarted = true;
                    aiLogic.AiRoll();
                }
                break;
            }
            case GamePhase.Ai2Turn:
            {
                gameUI.DrawEssentials();
                propetiesUI.DrawPropetiesUI();
                aiTurnUI.DrawAiUi();
                if (!aiTurnStarted)
                {
                    aiTurnStarted = true;
                    aiLogic.AiRoll();
                }
                break;
            }
            case GamePhase.OnLandTurn:
            {
                gameUI.DrawEssentials();
                propetiesUI.DrawPropetiesUI();
                onLandTurnUI.DrawOnLadUi(board);
                break;
            }
        }
    }
}
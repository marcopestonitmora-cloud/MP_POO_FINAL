using MP_POO_FINAL.GameScripts.GameWindow;
using MP_POO_FINAL.GameScripts.GameWindow.UI_s;
using MP_POO_FINAL.GameScripts.Managers;

namespace MP_POO_FINAL.GameScripts;

public class PhaseLogic
{
    private EventManager eventManager = EventManager.Instance;
    private StartRollUI startRollUi = new StartRollUI();
    private PlayerTurnUI playerUI = new PlayerTurnUI();
    private AiTurnUi aiTurnUI = new AiTurnUi();
    private WhoWinsTheRollUi rollWinnerUI = new WhoWinsTheRollUi();
    private GameUI gameUI;
    private GamePhase lastPhase =  GamePhase.RollToStart;
    
    public bool aiTurnStarted = false;

    public PhaseLogic(GameUI gameUi)
    {
        this.gameUI = gameUi;
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
                startRollUi.RollStart(gameUI.diceIcone);
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
                playerUI.DrawPlayerUI();
                break;
            }
            case GamePhase.Ai1Turn:
            {
                gameUI.DrawEssentials();
                aiTurnUI.DrawAiUi();
                if (!aiTurnStarted)
                {
                    aiTurnStarted = true;
                    Task.Run(async () => {await Task.Delay(1000); eventManager.GameEvents.aiEvents.AiTurnEnd();});
                }
                break;
            }
            case GamePhase.Ai2Turn:
            {
                gameUI.DrawEssentials();
                aiTurnUI.DrawAiUi();
                if (!aiTurnStarted)
                {
                    aiTurnStarted = true;
                    Task.Run(async () => {await Task.Delay(1000); eventManager.GameEvents.aiEvents.AiTurnEnd();});
                }
                break;
            }
        }
    }
}
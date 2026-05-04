using MP_POO_FINAL.GameScripts.GameWindow;
using MP_POO_FINAL.GameScripts.GameWindow.UI_s;
using MP_POO_FINAL.GameScripts.Managers;

namespace MP_POO_FINAL.GameScripts;

public class PhaseLogic
{
    private StartRoll startRoll = new StartRoll();
    private PlayerTurnUI playerUI = new PlayerTurnUI();
    private AiTurnUI aiTurnUI = new AiTurnUI();
    private WhoWinsTheRollUi rollWinnerUI = new WhoWinsTheRollUi();
    private GameUI gameUI;

    public PhaseLogic(GameUI gameUi)
    {
        this.gameUI = gameUi;
    }

    public void SceneChange()
    {
        switch (GameManagers.Instance.Phase)
        {
            case GamePhase.RollToStart:
            {
                gameUI.DrawEssentials();
                startRoll.RollStart(gameUI.diceIcone);
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
            case GamePhase.AiTurn:
            {
                gameUI.DrawEssentials();
                aiTurnUI.DrawAiUI();
                break;
            }
        }
    }
}
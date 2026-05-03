using MP_POO_FINAL.GameScripts.GameWindow;

namespace MP_POO_FINAL.GameScripts.Managers;

public class GameManagers
{
    private static readonly GameManagers _instance = new GameManagers(); 
    public static GameManagers Instance => _instance;
    public GameEvents GameEvents { get; } = new GameEvents(); 
    public GamePhase Phase { get; set; } = GamePhase.RollToStart;

    private GameManagers()
    {
        GameEvents.startRollEvent.OnStartRollEnd += async () => { Phase = GamePhase.WhoWinsTheRoll; await GameEvents.startRollEvent.WhoWinsTheRoll(); };
        GameEvents.startRollEvent.OnPlayerWins += () => Phase = GamePhase.Playing;
        GameEvents.startRollEvent.OnIAWins += () => Phase = GamePhase.AiTurn;
    }
}
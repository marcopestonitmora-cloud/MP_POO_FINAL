namespace MP_POO_FINAL.Managers;

public class EventManager
{
    private static readonly EventManager instance = new EventManager(); 
    public static EventManager Instance => instance;
    public GameEvents.GameEvents GameEvents { get; } = new GameEvents.GameEvents(); 
    public GamePhase Phase { get; set; } = GamePhase.RollToStart;
    
    public int CurrentTurn { get; set; } = 0; // 0 = Player, 1 = Ai1, 2 = Ai2
    

    private EventManager()
    {
        GameEvents.startRollEvent.OnStartRollEnd += async () =>
        {
            Phase = GamePhase.WhoWinsTheRoll; await GameEvents.startRollEvent.WhoWinsTheRoll();
        };
        
        GameEvents.startRollEvent.OnPlayerWins += () =>
        {
            CurrentTurn = 2;
            Phase = GamePhase.Playing;
        };
        
        GameEvents.startRollEvent.OnAi1Wins += () =>
        {
            CurrentTurn = 0;
            Phase = GamePhase.Ai1Turn;
        };
        
        GameEvents.startRollEvent.OnAi2Wins += () =>
        {
            CurrentTurn = 1;
            Phase = GamePhase.Ai2Turn;
        };
        
        GameEvents.aiEvents.OnNextAi2Turn += () =>
        {
            CurrentTurn = 1; 
            Phase = GamePhase.Ai2Turn;
        };

        GameEvents.aiEvents.OnNextPlayerTurn += () =>
        {
            CurrentTurn = 2; 
            Phase = GamePhase.Playing;
        };
    }
}
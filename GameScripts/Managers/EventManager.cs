using MP_POO_FINAL.Events;
using MP_POO_FINAL.GameScripts.Events;
using MP_POO_FINAL.GameWindow.BoardInfo;
using MP_POO_FINAL.GameWindow.Buttons;
using MP_POO_FINAL.GameWindow.Characters;
using MP_POO_FINAL.GameWindow.Dice;

namespace MP_POO_FINAL.Managers;

public class EventManager
{
    private static readonly EventManager instance = new EventManager();
    public static EventManager Instance => instance;
    public GameEvents GameEvents { get; } = new GameEvents(); 
    public GamePhase Phase { get; set; } = GamePhase.RollToStart;
    public ButtonsLogic ButtonsLogic { get; private set; }
    public Board board { get; private set; }
    public PropertyCell property { get; private set; }
    public int CurrentTurn { get; set; } = 0; // 0 = Player, 1 = Ai1, 2 = Ai2
    public Player player { get; private set; }
    public AI ai1 { get; private set; }
    public AI ai2 { get; private set; }
    

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
            GameEvents.diceRoll.Reset();
            Phase = GamePhase.Playing;
        };
    }
    
    public void InitCharacters(Player player, AI ai1, AI ai2)
    {
        this.player = player;
        this.ai1    = ai1;
        this.ai2    = ai2;

        player.OnRollEnd += () =>
        {
            Phase = GamePhase.OnLandTurn;
        };
    }

    public void InitBoard(Board board)
    {
        this.board = board;
    }
    
    public void InitButtonsLogic (ButtonsLogic buttonsLogic)
    {
        ButtonsLogic = buttonsLogic;

        buttonsLogic.OnPlayerTurnEnded += () =>
        {
            CurrentTurn = 0;
            Phase = GamePhase.Ai1Turn;
        };

        buttonsLogic.OnBuyProperty += () =>
        {
            property = board.GetCellIndex(player.BoardPosition) as PropertyCell;
            property?.Buy(OwnerType.Player);
        };
    }

    public Character GetCharacter(OwnerType ownerType)
    {
        switch (ownerType)
        {
            case OwnerType.Player:
            {
                return player;
            }
            case OwnerType.Ai1:
            {
                return ai1;
            }
            case OwnerType.Ai2:
            {
                return ai2;
            }
            default:
            {
                throw new InvalidOperationException("OwnerType no válido");
            }
        }
    }
}
using MP_POO_FINAL.Events;
using MP_POO_FINAL.GameScripts.Events;
using MP_POO_FINAL.GameWindow.BoardInfo;
using MP_POO_FINAL.GameWindow.Buttons;
using MP_POO_FINAL.GameWindow.Cards;
using MP_POO_FINAL.GameWindow.Characters;
using MP_POO_FINAL.GameWindow.Dice;

namespace MP_POO_FINAL.Managers;

public class EventManager
{
    private static readonly EventManager instance = new EventManager();
    public static EventManager Instance => instance;
    public GameEvents GameEvents { get; } = new GameEvents(); 
    public GamePhase Phase { get; set; } = GamePhase.RollToStart;
    public Deck<Card> CardDeck { get; private set; }

    public bool IsAnimating { get; set; } = false;
    public bool AlreadyRolled { get; set; } = false;
    public ButtonsLogic ButtonsLogic { get; private set; }
    public Board board { get; private set; }
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
            if (ai1.canRollAgain)
            {
                ai1.canRollAgain = false;
                GameEvents.diceRoll.Reset();
                Phase = GamePhase.Ai1Turn;
                return;
            }
            
            if (ai2.IsBankrupt || ai2.SkippedTurns > 0)
            {
                if (ai2.SkippedTurns > 0)
                {
                    ai2.SkippedTurns--;
                }
                CurrentTurn = 2;
                Phase = GamePhase.Playing;
                return;
            }
            
            CurrentTurn = 1; 
            Phase = GamePhase.Ai2Turn;
        };

        GameEvents.aiEvents.OnNextPlayerTurn += () =>
        {
            if (ai2.canRollAgain)
            {
                ai2.canRollAgain = false;
                GameEvents.diceRoll.Reset();
                Phase = GamePhase.Ai2Turn;
                return;
            }
            
            if (player.SkippedTurns > 0)
            {
                player.SkippedTurns--;
                CurrentTurn = 0;
                Phase = GamePhase.Ai1Turn;
                return;
            }

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
    
    public void InitDeck(Board board)
    {
        InitCards initCards = new InitCards(board);
        CardDeck = new Deck<Card>(initCards.CardBuilder());
    }
    
    public void AddCard(OwnerType owner, Card card)
    {
        Character character = GetCharacter(owner);
        if (character.Inventory.Count < 5)
        {
            card.Owner = owner;
            character.Inventory.Add(card);
        }
    }
    
    public void InitButtonsLogic (ButtonsLogic buttonsLogic)
    {
        ButtonsLogic = buttonsLogic;

        buttonsLogic.OnPlayerTurnEnded += () =>
        {
            if (player.canRollAgain)
            {
                player.canRollAgain = false;
                GameEvents.diceRoll.Reset();
                Phase = GamePhase.Playing;
                return;
            }
    
            if (ai1.IsBankrupt || ai1.SkippedTurns > 0)
            {
                if (ai1.SkippedTurns > 0) ai1.SkippedTurns--;
                CurrentTurn = 1;
                Phase = GamePhase.Ai2Turn;
                return;
            }

            CurrentTurn = 0;
            Phase = GamePhase.Ai1Turn;
        };

        buttonsLogic.OnBuyProperty += () =>
        {
            BoardCell cell = board.GetCellIndex(player.BoardPosition);
            cell?.Buy(OwnerType.Player);
        };

        buttonsLogic.OnSellProperty += () =>
        {
            BoardCell cell = board.GetCellIndex(player.BoardPosition);
            cell?.Sell(OwnerType.Player);
        };

        buttonsLogic.OnInventoryClicked += () =>
        {
            Phase = GamePhase.Inventory;
        };

        buttonsLogic.OnExitInventoryClicked += () =>
        {
            Phase = GamePhase.Playing;
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
    
    public async void CheckGameOver()
    {
        if (player.IsBankrupt)
        {
            Phase = GamePhase.GameOver;
            await Task.Delay(4000);
            Phase = GamePhase.BackToStart; // vuelve al inicio
            return;
        }

        if (ai1.IsBankrupt && ai2.IsBankrupt)
        {
            Phase = GamePhase.Win;
            await Task.Delay(4000);
            Phase = GamePhase.BackToStart;
        }
    }
}
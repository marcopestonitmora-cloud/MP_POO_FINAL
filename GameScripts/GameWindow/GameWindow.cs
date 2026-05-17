using MP_POO_FINAL.GameWindow.BoardInfo;
using MP_POO_FINAL.GameWindow.Buttons;
using MP_POO_FINAL.GameWindow.Cards;
using MP_POO_FINAL.GameWindow.Characters;
using MP_POO_FINAL.GameWindow.Characters.StateMachine;
using MP_POO_FINAL.GameWindow.Dice;
using MP_POO_FINAL.GameWindow.Screens;
using MP_POO_FINAL.GameWindow.UI_s;
using MP_POO_FINAL.Managers;
using Raylib_cs;

namespace MP_POO_FINAL.GameWindow;

public class GameWindow
{
    private MouseTracker mouse = new MouseTracker();
    private ButtonsLogic buttonLogic = new ButtonsLogic();
    private DrawDice diceNumbers =  new DrawDice();
    private AILogic ai1Logic;
    private AILogic ai2Logic;
    
    private Board board;
    private Player player;
    private AI ai1;
    private AI ai2;
    
    private IScreen currentScreen;
    
    private StartScreen startScreen = new StartScreen();
    private GameScreen gameScreen;

    public void Run()
    {
        player = new Player(500,OwnerType.Player);
        ai1 = new AI(500,OwnerType.Ai1);
        ai2 = new AI(500, OwnerType.Ai2);
        
        board  = BoardFactory.CreateBoard();
        
        EventManager.Instance.InitCharacters(player,ai1,ai2);
        EventManager.Instance.InitBoard(board);
        EventManager.Instance.InitDeck(board);
        foreach (Card card in EventManager.Instance.CardDeck.GetCards())
        {
            Console.WriteLine(card.Description);
        }
        EventManager.Instance.InitButtonsLogic(buttonLogic);
        
        ai1Logic  = new AILogic(ai1, board);
        ai2Logic  = new AILogic(ai2, board);
        gameScreen =  new GameScreen(player,ai1,ai2, diceNumbers, board);
        
        Raylib.InitWindow(1920, 1080, "Monopoly");

        foreach (var cell in board.GetAllCells())
        {
            cell.LoadAssets();
        }
        
        diceNumbers.LoadDiceNumbers();
        player.Coins.LoadNumbers();
        ai1.Coins.LoadNumbers();
        ai2.Coins.LoadNumbers();

        startScreen.LoadAssets();
        gameScreen.LoadAssets();
        
        currentScreen = startScreen;

        while (!Raylib.WindowShouldClose())
        {
            mouse.MouseTrack();
            currentScreen.Update(mouse, buttonLogic, player, ai1, ai2, board);

            if (startScreen.NextState == GameState.InGame)
            {
                currentScreen = gameScreen;
            }

            Raylib.BeginDrawing();
            currentScreen.Draw();
            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}
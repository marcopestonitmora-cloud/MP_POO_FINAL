using MP_POO_FINAL.GameWindow.BoardInfo;
using MP_POO_FINAL.Managers;

namespace MP_POO_FINAL.GameWindow.Characters.StateMachine;

public class AILogic
{
    private AI ai;
    private Board board;
    private AICardLogic cardLogic;
    private AIBuyLogic buyLogic;
    private AISellLogic sellLogic;

    public AILogic(AI ai, Board board)
    {
        this.ai    = ai;
        this.board = board;
        cardLogic  = new AICardLogic(ai,board);
        buyLogic   = new AIBuyLogic(ai, board);
        sellLogic  = new AISellLogic(ai);
    }

    public async Task ExecuteTurn()
    {
        cardLogic.UseCard();
    
        int steps = EventManager.Instance.GameEvents.diceRoll.RollTheDice();
        await ai.Move(steps, board);
    
        buyLogic.OnLand();
        sellLogic.EvaluateSell();

        if (ai.canRollAgain)
        {
            ai.canRollAgain = false;
            await ExecuteTurn(); // vuelve a ejecutar el turno
            return;
        }

        await Task.Delay(1000);
        EventManager.Instance.GameEvents.aiEvents.AiTurnEnd();
    }
}
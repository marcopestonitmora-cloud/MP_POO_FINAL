using MP_POO_FINAL.GameWindow.BoardInfo;
using MP_POO_FINAL.Managers;

namespace MP_POO_FINAL.GameWindow.Characters;

public class AiLogic
{
    private AI ai1;
    private AI ai2;
    private Board board;

    public AiLogic(AI ai1, AI ai2, Board board)
    {
        this.ai1 = ai1;
        this.ai2 = ai2;
        this.board = board;
    }

    public async Task AiRoll()
    {
        int steps = EventManager.Instance.GameEvents.diceRoll.RollTheDice();

        switch (EventManager.Instance.CurrentTurn)
        {
            case 0:
            {
                ai1.Move(steps, board);
                break;
            }
            case 1:
            {
                ai2.Move(steps, board);
                break;
            }
        }
    }
}
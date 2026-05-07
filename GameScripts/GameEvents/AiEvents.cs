using MP_POO_FINAL.Managers;

namespace MP_POO_FINAL.GameEvents;

public class AiEvents
{
    public event Action OnNextAi2Turn;
    public event Action OnNextPlayerTurn;
    
    public async Task AiTurnEnd()
    {
        await Task.Delay(1000);
        
        if (EventManager.Instance.CurrentTurn == 0)
        {
            EventManager.Instance.CurrentTurn = 1;
            OnNextAi2Turn?.Invoke();
        }
        else if (EventManager.Instance.CurrentTurn == 1)
        {
            EventManager.Instance.CurrentTurn = 2;
            OnNextPlayerTurn?.Invoke();
        }
    }
}
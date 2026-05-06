using System.Numerics;

using MP_POO_FINAL.GameScripts.GameWindow.Board;

public abstract class Character
{
    public int InvicoinsCounter {get; private set;}
    public int BoardPosition {get; private set;}
    public Vector2 ScreenPosition {get; private set;}
    //public Inventory<ActionCard> Cards { get; protected set; }
    public List<PropertyCell> Properties { get; protected set; }
    public bool IsBankrupt { get; protected set; } = false;

    protected Character(int invicoinsCounter,int boardPosition, Vector2 screenPosition)
    {
        InvicoinsCounter = invicoinsCounter;
        ScreenPosition = screenPosition;
        BoardPosition = boardPosition;
    }
}
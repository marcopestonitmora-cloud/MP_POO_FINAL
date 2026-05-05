namespace MP_POO_FINAL;

public class Board
{
    private readonly BoardCell[] _cells;
    public int CellCounter => _cells.Length;

    public Board(BoardCell[] cells)
    {
        if (cells == null || cells.Length == 0)
        {
            throw new ArgumentException("No cells found");
        }
        _cells = cells;
    }
    
    public BoardCell GetCellIndex(int diceNumber)
    {
        int i = ((diceNumber % CellCounter) + CellCounter) % CellCounter; //Hace el modulo de 27, si el player pasa de la casilla 27 vuelve al principio.
        return _cells[i];
    }
}
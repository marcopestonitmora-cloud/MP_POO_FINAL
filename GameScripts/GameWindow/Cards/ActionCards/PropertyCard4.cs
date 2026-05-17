using MP_POO_FINAL.GameWindow.BoardInfo;
using MP_POO_FINAL.GameWindow.Characters;
using MP_POO_FINAL.Managers;
using Raylib_cs;

namespace MP_POO_FINAL.GameWindow.Cards.ActionCards;

public class PropertyCard4 : Card
{
    private Board Board;
    
    public PropertyCard4(string type, string description, OwnerType owner, Color color, Board board) : base(type, description, owner, color)
    {
        Board = board;
    }

    //Ganas dos creditos en todas tus propiedades
    public override void ActionCard(EventManager manager, OwnerType user)
    {
        Random random = new Random();

        foreach (BoardCell cell in Board.GetAllCells())
        {
            if (cell is PropertyCell property)
            {
                if (property.CellOwner == user )
                {
                    property.CreditCounter += 2;
                }
            }
        }
    }
}
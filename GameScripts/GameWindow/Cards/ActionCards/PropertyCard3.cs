using MP_POO_FINAL.GameWindow.BoardInfo;
using MP_POO_FINAL.GameWindow.Characters;
using MP_POO_FINAL.Managers;
using Raylib_cs;

namespace MP_POO_FINAL.GameWindow.Cards.ActionCards;

public class PropertyCard3 : Card
{
    private Board Board { get; set; }
    private int number;
    
    public PropertyCard3(string type, string description, OwnerType owner, Color color, Board board) : base(type, description, owner, color)
    {
        Board = board;
    }

    //Triplica el precio que te pagan al caer en una casilla (se mantiene para el resto de la partida), independientemente de los creditos
    public override void ActionCard(EventManager manager, OwnerType user)
    {
        Random random = new Random();

        // Propiedades rivales con créditos
        List<PropertyCell> userPropeties = new List<PropertyCell>();

        foreach (BoardCell cell in Board.GetAllCells())
        {
            if (cell is PropertyCell property)
            {
                if (property.CellOwner == user)
                {
                    userPropeties.Add(property);
                }
            }
        }
        
        number = random.Next(userPropeties.Count);
        PropertyCell selectedProperty = userPropeties[number];
        selectedProperty.RentPrice *= 5;
    }

    // No hay propiedades válidas
}
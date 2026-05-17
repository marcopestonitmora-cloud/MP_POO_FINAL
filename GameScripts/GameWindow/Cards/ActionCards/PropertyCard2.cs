using MP_POO_FINAL.GameWindow.BoardInfo;
using MP_POO_FINAL.GameWindow.Characters;
using MP_POO_FINAL.Managers;
using Raylib_cs;

namespace MP_POO_FINAL.GameWindow.Cards.ActionCards;

public class PropertyCard2: Card
{
    private Board Board;
    private int number { get; set; } = 0;
    
    public PropertyCard2(string type, string description, OwnerType owner, Color color, Board board) : base(type, description, owner, color)
    {
        Board = board;
    }

    //Elimina todos los creditos de una propiedad de alguno de los dos rivales
    public override void ActionCard(EventManager manager, OwnerType user)
    {
        Random random = new Random();

        // Propiedades rivales con créditos
        List<PropertyCell> validProperties = new List<PropertyCell>();

        foreach (BoardCell cell in Board.GetAllCells())
        {
            if (cell is PropertyCell property)
            {
                if (property.CellOwner != user && property.CellOwner != OwnerType.None && property.CreditCounter > 0)
                {
                    validProperties.Add(property);
                }
            }
        }

        // No hay propiedades válidas
        if (validProperties.Count == 0)
        {
            Console.WriteLine("No hay propiedades con créditos.");
            return;
        }

        int number = random.Next(validProperties.Count);
        PropertyCell selectedProperty = validProperties[number];
        selectedProperty.CreditCounter = 0;
    } 
}
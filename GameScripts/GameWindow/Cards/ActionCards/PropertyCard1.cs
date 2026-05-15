using MP_POO_FINAL.GameWindow.BoardInfo;
using MP_POO_FINAL.GameWindow.Characters;
using MP_POO_FINAL.Managers;

namespace MP_POO_FINAL.GameWindow.Cards.ActionCards;

public class PropertyCard1 : Card
{
    private Board Board;
    private int number { get; set; } = 0;
    
    public PropertyCard1(string type, string description, OwnerType owner, Board board) : base(type, description, owner)
    {
        Board = board;
    }

    //Robas la propiedad de un rival pagando solo el 30% de su valor
    public override void ActionCard(EventManager manager, OwnerType user)
    {
        Random random = new Random();

        // Lista de propiedades que pertenecen a otros jugadores
        List<PropertyCell> enemyProperties = new List<PropertyCell>();

        foreach (BoardCell cell in Board.GetAllCells())
        {
            if (cell is PropertyCell property)
            {
                if (property.CellOwner != user && property.CellOwner != OwnerType.None)
                {
                    enemyProperties.Add(property);
                }
            }
        }
        
        if (enemyProperties.Count == 0)
        {
            Console.WriteLine("No hay propiedades para robar.");
            return;
        }

        // Se escoge una propiedad aleatoria
        number = random.Next(enemyProperties.Count);
        PropertyCell stolenProperty = enemyProperties[number];
        EventManager.Instance.GetCharacter(user).LoseInvicions((int)(stolenProperty.Price * 0.3f));
        stolenProperty.CellOwner = user;

        Console.WriteLine($"Has robado {stolenProperty.Index} pagando {stolenProperty.Price}");
    }
}
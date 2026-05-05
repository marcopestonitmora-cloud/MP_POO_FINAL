using System.Numerics;

namespace MP_POO_FINAL;

public abstract class BoardCell
{
    public int Index { get; private set; }
    public string Name { get; private set; }
    public Vector2 ScreenPosition { get; private set; }

    protected BoardCell(int index, string name, Vector2 screenPosition)
    {
        if (index < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("El nombre no puede estar vacío.", nameof(name));
        }

        Index          = index;
        Name           = name;
        ScreenPosition = screenPosition;
    }

    public abstract void OnLand(OwnerType currentPlayer);  
    //Metodo para cuando el player cae en dicha casilla. Permite comprarla o pagar al propietario si no esta ocupada.
    //Si la compra le dan una tarjeta de accion aleatoria
    //Si tiene propietario que salte el evento y le pague
}
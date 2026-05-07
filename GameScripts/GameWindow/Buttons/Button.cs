namespace MP_POO_FINAL.GameWindow.Buttons;

public class Button(int x, int y, int width, int height)
{
    private bool isOver = false;
    private bool isPressed = false;

    public void Update(MouseTracker mouse)
    {
        // ver si el mouse esta encima del boton
        isOver = mouse.mousePosition.X >= x && mouse.mousePosition.X <= x + width &&
                 mouse.mousePosition.Y >= y && mouse.mousePosition.Y <= y + height;

        // solo esta presionado si esta encima Y clickeado
        isPressed = isOver && mouse.clicked;
    }

    public bool IsClicked()
    {
        return isPressed;
    }
}
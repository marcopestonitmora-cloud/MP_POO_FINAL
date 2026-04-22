using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace MP_POO_FINAL;

public class MouseTracker
{
    private bool isPressed = false;
    private bool onPress = false;
    private bool onRelease = false;
    
    private Vector2i mousePosition;
    private Vector2f mouseVector;

    public void UpdateMouse(RenderWindow window)
    {
        mousePosition = Mouse.GetPosition(window);
        mouseVector = new Vector2f(mousePosition.X, mousePosition.Y);

        onPress = false;
        onRelease = false;

        if (Mouse.IsButtonPressed(Mouse.Button.Left))
        {
            if (!isPressed)
            {
                onPress = true;
            }
            isPressed = true;
        }
        else
        {
            if (isPressed)
            {
                onRelease = true;
            }
            isPressed = false;
        }
    }
}
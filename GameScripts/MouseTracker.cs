using System.Diagnostics;
using System.Numerics;
using Raylib_cs;

namespace MP_POO_FINAL.GameScripts;

public class MouseTracker
{
    public Vector2 mousePosition;
    public bool clicked;

    public void MouseTrack()
    {
        mousePosition = new Vector2(Raylib.GetMouseX(), Raylib.GetMouseY());
        
        ClickTracker();
    }

    public bool ClickTracker()
    {
        clicked = Raylib.IsMouseButtonPressed(MouseButton.Left);
        return clicked;
    }
}
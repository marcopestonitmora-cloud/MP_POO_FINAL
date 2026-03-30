using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SFML.Audio;

namespace MP_POO_FINAL;

public class GameWindow
{
    public static void Window()
    {
        RenderWindow gameplayWindow = new RenderWindow(new VideoMode((1920, 1080), 600),"GameWindow");
        gameplayWindow.SetFramerateLimit(60);

        while (gameplayWindow.IsOpen)
        {
            gameplayWindow.DispatchEvents();
        }
    }
}
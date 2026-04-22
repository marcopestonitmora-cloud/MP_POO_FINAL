using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SFML.Audio;

namespace MP_POO_FINAL;

public class GameWindow
{
    private static Texture texture_background;
    private static Sprite background;
    
    
    public static void Window()
    {
        texture_background = new Texture("Sprites/background.png");
        background =  new Sprite(texture_background);
        RenderWindow gameplayWindow = new RenderWindow(new VideoMode((1920, 1080), 600),"GameWindow");
        gameplayWindow.SetFramerateLimit(60);

        while (gameplayWindow.IsOpen)
        {
            gameplayWindow.DispatchEvents();
            gameplayWindow.Draw(background);
        }
    }
}


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
        RenderWindow gameplayWindow = new RenderWindow(new VideoMode((1920, 1080), 600),"GameWindow");
        gameplayWindow.SetFramerateLimit(60);
        
        //Background
        texture_background = new Texture("Sprites/casino_background.png");
        background =  new Sprite(texture_background);
        background.Position = new Vector2f(0, 0);
        background.Scale = new Vector2f(1.3f, 1.3f);
        
        //Board
        
        

        while (gameplayWindow.IsOpen)
        {
            gameplayWindow.DispatchEvents();
            gameplayWindow.Clear(color:Color.White);
            gameplayWindow.Draw(background);
            gameplayWindow.Display();
        }
    }
}


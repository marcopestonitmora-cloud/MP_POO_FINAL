using System.Numerics;
using MP_POO_FINAL.GameScripts.GameWindow.Buttons;
using Raylib_cs;

namespace MP_POO_FINAL.GameScripts.GameWindow;

public class StartUI
{
    private Texture2D background;
    private Texture2D startButton;


    public Button playButton = new Button(850, 950, 200, 100);
    
    public void LoadAssets()
    {
        background = Raylib.LoadTexture("Sprites/StartPicture.png");
        startButton = Raylib.LoadTexture("Sprites/StartButton.png");
    }

    public void LoadWindowInfo()
    {
        Raylib.ClearBackground(Color.White);
        Raylib.DrawTextureEx(background, new Vector2(0,0), 0f, 1.42f, Color.White);
        Raylib.DrawTextureEx(startButton, new Vector2(700,850), 0f, 0.4f, Color.White);
    }
}
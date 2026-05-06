using MP_POO_FINAL.GameScripts.GameWindow.Buttons;
using MP_POO_FINAL.GameScripts.GameWindow.UI_s;

namespace MP_POO_FINAL.GameScripts.GameWindow.Screens;

public class StartScreen : IScreen
{
    StartUI startUi = new StartUI();
    public GameState? NextState { get; private set; }
    

    public void LoadAssets() => startUi.LoadAssets();


    public void Update(MouseTracker mouse, ButtonsLogic buttonLogic)
    {
        if (buttonLogic.PlayButton(startUi.playButton, mouse))
        {
            NextState = GameState.InGame;
        }
    }

    public void Draw() => startUi.LoadWindowInfo();
}
using MP_POO_FINAL.GameWindow.BoardInfo;
using MP_POO_FINAL.GameWindow.Buttons;
using MP_POO_FINAL.GameWindow.Characters;
using MP_POO_FINAL.GameWindow.UI_s;

namespace MP_POO_FINAL.GameWindow.Screens;

public class StartScreen : IScreen
{
    StartUI startUi = new StartUI();
    public GameState? NextState { get; private set; }
    

    public void LoadAssets() => startUi.LoadAssets();
    public void Update(MouseTracker mouse, ButtonsLogic buttonLogic, Character characters, Character ai1, Character ai2,Board board)
    {
        if (buttonLogic.PlayButton(startUi.playButton, mouse))
        {
            NextState = GameState.InGame;
        }
    }

    public void Draw() => startUi.LoadWindowInfo();
    public void Reset()
    {
        NextState = null;
    }
}
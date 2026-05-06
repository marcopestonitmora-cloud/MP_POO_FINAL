using MP_POO_FINAL.GameScripts.GameWindow.Buttons;

namespace MP_POO_FINAL.GameScripts.GameWindow.Screens;

public enum GameState {Start,InGame}

public interface IScreen
{
    void LoadAssets();
    void Update(MouseTracker mouse, ButtonsLogic buttonLogic);
    void Draw();
}
using MP_POO_FINAL.GameScripts.GameWindow.Buttons;
using SFML.Window;

namespace MP_POO_FINAL.GameScripts.GameWindow;

public enum GameState {Start,InGame}

public interface IScreen
{
    void LoadAssets();
    void Update(MouseTracker mouse, ButtonsLogic buttonLogic);
    void Draw();
}
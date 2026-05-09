using MP_POO_FINAL.GameWindow.BoardInfo;
using MP_POO_FINAL.GameWindow.Buttons;
using MP_POO_FINAL.GameWindow.Characters;

namespace MP_POO_FINAL.GameWindow.Screens;

public enum GameState {Start,InGame}

public interface IScreen
{
    void LoadAssets();
    void Update(MouseTracker mouse, ButtonsLogic buttonLogic, Character player, Character ai1, Character ai2, Board board);
    void Draw();
}
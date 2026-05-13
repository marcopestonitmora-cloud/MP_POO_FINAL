using System.Numerics;
using MP_POO_FINAL.GameWindow.BoardInfo;
using MP_POO_FINAL.GameWindow.Buttons;
using MP_POO_FINAL.GameWindow.Characters;
using MP_POO_FINAL.Managers;
using Raylib_cs;

namespace MP_POO_FINAL.GameWindow.UI_s;

public class OnLandTurnUi
{
    private GameUi gameUi;
    
    private Player player => EventManager.Instance.player;
    
    private string infoText = "INFO";
    private string endTurnText = "END TURN";

    public Button buyButton = new Button(57, 990, 200, 50);
    public Button infoButton = new Button(57, 760, 200, 50);
    public Button sellButton = new Button(57, 760, 200, 50);
    public Button endTurnButton = new Button(1600, 1010, 200, 50);

    public OnLandTurnUi(GameUi gameUi)
    {
        this.gameUi = gameUi;
    }
    
    public void DrawOnLadUi(Board board)
    {
        
        BoardCell boardCell = board.GetCellIndex(player.BoardPosition);

        if (boardCell == null)
        {
            return;
        }
        
        Raylib.DrawTextureEx(gameUi.endTurnIcone, new Vector2(1520, 790), 0, 0.6f, Color.White);
        Raylib.DrawText(endTurnText, 1560, 990, 60, Color.White);

        Raylib.DrawRectangle(1515, 50, 400, 60, Color.Black);
        Raylib.DrawText("Turn: Player", 1520, 50, 60, Color.Blue);

        Raylib.DrawTextureEx(gameUi.infoIcone, new Vector2(120, 790), 0, 0.6f, Color.White);
        Raylib.DrawText(infoText, 250, 990, 60, Color.White);
        
        board.GetCellIndex(player.BoardPosition).DrawOnLandUI();
    }
}
using System.Numerics;
using MP_POO_FINAL.GameWindow.BoardInfo;
using MP_POO_FINAL.GameWindow.Buttons;
using MP_POO_FINAL.GameWindow.Characters;
using MP_POO_FINAL.Managers;
using Raylib_cs;

namespace MP_POO_FINAL.GameWindow.UI_s;

public class OnLandTurnUi
{
    private Player player => EventManager.Instance.player;

    private string buyText = "BUY";
    private string infoText = "INFO";
    private string sellText = "SELL";
    private string endTurnText = "END TURN";

    private Texture2D buyIcone;
    private Texture2D infoIcone;
    private Texture2D endTurnIcone;

    public Button buyButton = new Button(116, 1010, 200, 50);
    public Button infoButton = new Button(1600, 1010, 200, 50);
    public Button sellButton = new Button(1600, 1010, 200, 50);
    public Button endTurnButton = new Button(1600, 1010, 200, 50);

    public void DrawOnLadUi(Board board)
    {
        buyIcone = Raylib.LoadTexture("Sprites/IV_money.png");
        infoIcone = Raylib.LoadTexture("Sprites/InfoIcone.png");
        endTurnIcone = Raylib.LoadTexture("Sprites/EndTurnIcone.png");
        
        BoardCell boardCell = board.GetCellIndex(player.BoardPosition);

        if (boardCell == null)
        {
            return;
        }

        PropertyCell property = boardCell as PropertyCell;
        
        Raylib.DrawTextureEx(endTurnIcone, new Vector2(1520, 790), 0, 0.6f, Color.White);
        Raylib.DrawText(endTurnText, 1560, 990, 60, Color.White);

        Raylib.DrawRectangle(1515, 50, 400, 60, Color.Black);
        Raylib.DrawText("Turn: Player", 1520, 50, 60, Color.Blue);
        
        if (property == null)
        {
            return;
        }
        
        Raylib.DrawTextureEx(infoIcone, new Vector2(120, 790), 0, 0.6f, Color.White);
        Raylib.DrawText(infoText, 250, 990, 60, Color.White);

        switch (property.Owner)
        {
            case OwnerType.None:
            {
                Raylib.DrawTextureEx(buyIcone, new Vector2(57, 860), 0, 0.6f, Color.White);
                Raylib.DrawText(buyText, 70, 990, 60, Color.White);
                break;
            }

            case OwnerType.Player:
            {
                Raylib.DrawTextureEx(buyIcone, new Vector2(80, 850), 0, 1f, Color.White);
                Raylib.DrawText(buyText, 160, 900, 50, Color.White);
                Raylib.DrawText(sellText, 1500, 600, 50, Color.White);
                break;
            }
        }
    }
}
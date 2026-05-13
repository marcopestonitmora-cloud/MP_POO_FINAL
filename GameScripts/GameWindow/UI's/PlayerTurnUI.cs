using System.Numerics;
using MP_POO_FINAL.GameWindow.BoardInfo;
using MP_POO_FINAL.GameWindow.Buttons;
using MP_POO_FINAL.GameWindow.Dice;
using MP_POO_FINAL.Managers;
using Raylib_cs;

namespace MP_POO_FINAL.GameWindow.UI_s;

public class PlayerTurnUI
{
    private string diceText = "ROLL";
    private string inventoryText = "INVENTORY";
    
    public Button diceButton = new Button(116, 1010, 200, 50);
    public Button inventoryButton = new Button(1600, 1010, 200, 50);
    
    private DiceRoll diceRoll => EventManager.Instance.GameEvents.diceRoll;
    private DrawDice diceNumbers;
    
    private GameUi gameUi;

    public PlayerTurnUI(DrawDice diceNumbers,  GameUi gameUi)
    {
        this.diceNumbers = diceNumbers;
        this.gameUi = gameUi;
    }
    
    public void DrawPlayerUI()
    {
        Raylib.DrawRectangle(1515, 50, 400, 60, Color.Black);
        Raylib.DrawText("Turn: Player",1520,50,60,Color.Blue);
        
        Raylib.DrawTextureEx(gameUi.diceIcone, new Vector2(80,850), 0, 0.3f, Color.White);
        Raylib.DrawText(diceText,160,1010,50,Color.White);
        
        Raylib.DrawTextureEx(gameUi.cardIcone, new Vector2(1600,800), 0f, 0.2f, Color.White);
        Raylib.DrawText(inventoryText,1560,1010,50,Color.White);
        
        if (diceRoll.HasRolled)
        {
            diceNumbers.Draw(diceRoll.Number);
        }
    }
}
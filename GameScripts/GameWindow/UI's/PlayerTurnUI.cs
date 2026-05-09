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
    
    private Texture2D diceIcone;
    private Texture2D cardIcone;
    
    public Button diceButton = new Button(116, 1010, 200, 50);
    public Button inventoryButton = new Button(1600, 1010, 200, 50);
    
    private DiceRoll diceRoll => EventManager.Instance.GameEvents.diceRoll;
    private DrawDice diceNumbers;

    public PlayerTurnUI(DrawDice diceNumbers)
    {
        this.diceNumbers = diceNumbers;
    }

    public void DrawPlayerUI()
    {
        Raylib.DrawRectangle(1515, 50, 400, 60, Color.Black);
        Raylib.DrawText("Turn: Player",1520,50,60,Color.Blue);
        
        cardIcone = Raylib.LoadTexture("Sprites/CardIcone.png");
        diceIcone = Raylib.LoadTexture("Sprites/DiceIcone.png");
        
        Raylib.DrawTextureEx(diceIcone, new Vector2(80,850), 0, 0.3f, Color.White);
        Raylib.DrawText(diceText,160,1010,50,Color.White);
        
        Raylib.DrawTextureEx(cardIcone, new Vector2(1600,800), 0f, 0.2f, Color.White);
        Raylib.DrawText(inventoryText,1560,1010,50,Color.White);
        
        if (diceRoll.HasRolled)
        {
            diceNumbers.Draw(diceRoll.Number);
        }
    }
}
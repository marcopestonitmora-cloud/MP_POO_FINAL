using MP_POO_FINAL.GameScripts.GameWindow.Buttons;
using Raylib_cs;

namespace MP_POO_FINAL.GameScripts.GameWindow;

public class ExtrasUI
{
        
    private string diceText = "TIRAR";
    private string inventoryText = "INVENTARIO";
    
    private Texture2D cardIcone;
    
    public Button diceButton = new Button(116, 1010, 200, 50);
    public Button inventoryButton = new Button(1600, 1010, 200, 50);
    
    public void LoadWindowInfo()
    {
        //Raylib.DrawTextureEx(diceIcone, new Vector2(80,850), 0, 0.3f, Color.White);
        //Raylib.DrawText(diceText,130,1010,50,Color.White);
        //Raylib.DrawTextureEx(cardIcone, new Vector2(1600,800), 0f, 0.2f, Color.White);
        //Raylib.DrawText(inventoryText,1540,1010,50,Color.White);
        //cardIcone = Raylib.LoadTexture("Sprites/CardIcone.png");
    }
}
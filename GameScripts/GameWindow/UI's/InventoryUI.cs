using System.Numerics;
using MP_POO_FINAL.GameWindow.Buttons;
using MP_POO_FINAL.GameWindow.Cards;
using MP_POO_FINAL.Managers;
using Raylib_cs;

namespace MP_POO_FINAL.GameWindow.UI_s;


public class InventoryUI
{
    private GameUi gameUi;
    List<Card> inventory = EventManager.Instance.player.Inventory;
    public Button exitButton = new Button(1700, 980, 200, 80);

    public InventoryUI(GameUi gameUi)
    {
        this.gameUi = gameUi;
    }

    public void DrawInventory()
    {
        Raylib.ClearBackground(Color.Black);
        Raylib.DrawTextureEx(gameUi.background, new Vector2(0, 0), 0f, 1.3f, Color.White);

        int cardWidth  = 340;
        int cardHeight = 500;
        int margin     = 80;
        int spacing    = (1920 - margin * 2 - cardWidth * 5) / 4;

        Vector2 mousePos = Raylib.GetMousePosition();
        
        //Dibuja las cartas del inventario dejando un espacio entre ellas, asi como el reborde naranja y si la clikas efectua su efecto y se elimina
        for (int i = 0; i < inventory.Count; i++)
        {
            int x = margin + i * (cardWidth + spacing);
            int y = 300;
            int fontSize  = 25;
            int textWidth = Raylib.MeasureText(inventory[i].Type, fontSize);
            int textX     = x + (cardWidth - textWidth) / 2;

            bool isHovered = mousePos.X >= x && mousePos.X <= x + cardWidth && mousePos.Y >= y && mousePos.Y <= y + cardHeight;
            bool isClicked = isHovered && Raylib.IsMouseButtonPressed(MouseButton.Left);

            Raylib.DrawRectangle(x, y, cardWidth, cardHeight, Color.White);
    
            if (isHovered)
            {
                Raylib.DrawRectangleLinesEx(new Rectangle(x - 3, y - 3, cardWidth + 6, cardHeight + 6), 4, Color.Orange);
            }

            Raylib.DrawRectangle(textX - 5, y + 10, textWidth + 10, fontSize + 10, Color.Black);
            Raylib.DrawText(inventory[i].Type, textX, y + 15, fontSize, inventory[i].Color);
            Raylib.DrawTextEx(Raylib.GetFontDefault(), inventory[i].Description, new Vector2(x + 10, y + 60), 22, 2, Color.Black);
            
            if (isClicked)
            {
                inventory[i].ActionCard(EventManager.Instance, inventory[i].Owner);
                inventory.RemoveAt(i);
                break; 
            }
        }
        
        Raylib.DrawRectangle(1700, 980, 200, 80, Color.Red);
        int exitWidth = Raylib.MeasureText("EXIT", 40);
        Raylib.DrawText("EXIT", 1700 + (200 - exitWidth) / 2, 980 + (80 - 40) / 2, 40, Color.White);
    }
}
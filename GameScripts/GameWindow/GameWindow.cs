using System.Numerics;
using MP_POO_FINAL.GameScripts;
using Raylib_cs;

namespace MP_POO_FINAL;

public class GameWindow 
{   
    MouseTracker mouse =  new MouseTracker();
    ButtonsLogic buttonLogic = new ButtonsLogic();
    GameUI ui = new GameUI();
    
    private int width = 1920;
    private int height = 1080;
    
    public void InitWindowRaylib()
    {
        Raylib.InitWindow(width, height, "Mi Juego en Raylib");
        ui.LoadAssets();
        
        while (!Raylib.WindowShouldClose())
        {
            buttonLogic.DiceButton(ui.diceButton,mouse);
            buttonLogic.InventoryButton(ui.inventoryButton,mouse);
            mouse.MouseTrack();
            Raylib.BeginDrawing();
            ui.LoadWindowInfo();
            Raylib.EndDrawing();
        }
        Raylib.CloseWindow(); 
    }
}




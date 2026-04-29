using System.Numerics;
using MP_POO_FINAL.GameScripts;
using Raylib_cs;

namespace MP_POO_FINAL;

public class ButtonsLogic
{
    public void DiceButton(Button playButton, MouseTracker mouse)
    {
        playButton.Update(mouse);

        if (playButton.IsClicked())
        {
            Console.WriteLine("Boton presionado!");
        }
    }

    public void InventoryButton(Button inventoryButton, MouseTracker mouse)
    {
        inventoryButton.Update(mouse);

        if (inventoryButton.IsClicked())
        {
            Console.WriteLine("Boton presionado!");
        }
    }
}
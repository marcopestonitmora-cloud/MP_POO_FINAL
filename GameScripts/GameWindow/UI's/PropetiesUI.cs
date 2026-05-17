using MP_POO_FINAL.GameWindow.BoardInfo;
using MP_POO_FINAL.Managers;
using Raylib_cs;

namespace MP_POO_FINAL.GameWindow.UI_s;

public class PropetiesUI
{
    private Board board;

    public PropetiesUI(Board board)
    {
        this.board = board;
    }

    public void DrawPropetiesUI()
    {
        int propertyPlayer = 0;
        int propertyAi1 = 0;
        int propertyAi2 = 0;

        int monsterPlayer = 0;
        int monsterAi1 = 0;
        int monsterAi2 = 0;

        foreach (BoardCell cell in board.GetAllCells())
        {
            if (cell is PropertyCell property && cell.CellOwner != OwnerType.None)
            {
                switch (cell.CellOwner)
                {
                    case OwnerType.Player:
                    {
                        Raylib.DrawRectangle(132 + propertyPlayer, 160, 20, 40, property.Color);
                        Raylib.DrawText($"{property.CreditCounter}", 135 + propertyPlayer, 170, 20, Color.White);
                        propertyPlayer += 25;
                        break;
                    }
                    case OwnerType.Ai1:
                    {
                        Raylib.DrawRectangle(132 + propertyAi1, 320, 20, 40, property.Color);
                        Raylib.DrawText($"{property.CreditCounter}", 135 + propertyAi1, 330, 20, Color.White);
                        propertyAi1 += 25;
                        break;
                    }
                    case OwnerType.Ai2:
                    {
                        Raylib.DrawRectangle(132 + propertyAi2, 480, 20, 40, property.Color);
                        Raylib.DrawText($"{property.CreditCounter}", 135 + propertyAi2, 490, 20, Color.White);
                        propertyAi2 += 25;
                        break;
                    }
                }
            }
            else if (cell is MonsterCell monster && cell.CellOwner != OwnerType.None)
            {
                switch (cell.CellOwner)
                {
                    case OwnerType.Player:
                    {
                        Raylib.DrawRectangle(130 + monsterPlayer, 45, 20, 40, monster.Color);
                        Raylib.DrawText("M", 132 + monsterPlayer, 55, 20, Color.Black);
                        monsterPlayer += 25;
                        break;
                    }
                    case OwnerType.Ai1:
                    {
                        Raylib.DrawRectangle(130 + monsterAi1, 205, 20, 40, monster.Color);
                        Raylib.DrawText("M", 132 + monsterAi1, 215, 20, Color.Black);
                        monsterAi1 += 25;
                        break;
                    }
                    case OwnerType.Ai2:
                    {
                        Raylib.DrawRectangle(130 + monsterAi2, 365, 20, 40, monster.Color);
                        Raylib.DrawText("M", 132 + monsterAi2, 375, 20, Color.Black);
                        monsterAi2 += 25;
                        break;
                    }
                }
            }
        }
    }
}
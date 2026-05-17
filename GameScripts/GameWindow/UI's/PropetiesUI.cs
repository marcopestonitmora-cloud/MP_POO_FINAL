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
        int increasePlayer = 0;
        int increaseAi1 = 0;
        int increaseAi2 = 0;

        foreach (BoardCell cell in board.GetAllCells())
        {
            if (cell is PropertyCell property && cell.CellOwner != OwnerType.None)
            {
                switch (cell.CellOwner)
                {
                    case OwnerType.Player:
                    {
                        Raylib.DrawRectangle(130 + increasePlayer, 160, 20, 40, property.Color);
                        Raylib.DrawText($"{property.CreditCounter}", 135 + increasePlayer, 170, 20, Color.White);
                        increasePlayer += 25;
                        break;
                    }
                    case OwnerType.Ai1:
                    {
                        Raylib.DrawRectangle(132 + increaseAi1, 320, 20, 40, property.Color);
                        Raylib.DrawText($"{property.CreditCounter}", 135 + increaseAi1, 330, 20, Color.White);
                        increaseAi1 += 25;
                        break;
                    }
                    case OwnerType.Ai2:
                    {
                        Raylib.DrawRectangle(132 + increaseAi2, 480, 20, 40, property.Color);
                        Raylib.DrawText($"{property.CreditCounter}", 135 + increaseAi2, 490, 20, Color.White);
                        increaseAi2 += 25;
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
                        Raylib.DrawRectangle(130 + increasePlayer, 45, 20, 40, monster.Color);
                        Raylib.DrawText("M", 132 + increasePlayer, 55, 20, Color.Black);
                        increasePlayer += 25;
                        break;
                    }
                    case OwnerType.Ai1:
                    {
                        Raylib.DrawRectangle(130 + increaseAi1, 205, 20, 40, monster.Color);
                        Raylib.DrawText("M", 132 + increaseAi1, 215, 20, Color.Black);
                        increaseAi1 += 25;
                        break;
                    }
                    case OwnerType.Ai2:
                    {
                        Raylib.DrawRectangle(130 + increaseAi2, 365, 20, 40, monster.Color);
                        Raylib.DrawText("M", 132 + increaseAi2, 375, 20, Color.Black);
                        increaseAi2 += 25;
                        break;
                    }
                }
            }
        }
    }
}
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
        int increase_X = 0;
        
        foreach (BoardCell cell in board.GetAllCells())
        {
            if (cell is PropertyCell property && cell.CellOwner != OwnerType.None)
            {
                switch (cell.CellOwner)
                {
                    case OwnerType.Player:
                    {
                        Raylib.DrawRectangle(130+increase_X,160,20,40,property.Color);
                        Raylib.DrawText($"{property.CreditCounter}", 135 + increase_X, 170, 20, Color.White);
                        increase_X += 25;
                        break;
                    }
                    case OwnerType.Ai1:
                    {
                        Raylib.DrawRectangle(130+increase_X,320,20,40,property.Color);
                        Raylib.DrawText($"{property.CreditCounter}", 135 + increase_X, 170, 20, Color.White);
                        increase_X += 25;
                        break;
                    }
                    case OwnerType.Ai2:
                    {
                        Raylib.DrawRectangle(130+increase_X,480,20,40,property.Color);
                        Raylib.DrawText($"{property.CreditCounter}", 135 + increase_X, 170, 20, Color.White);
                        increase_X += 25;
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
                        Raylib.DrawRectangle(130+increase_X,40,20,40,monster.Color);
                        Raylib.DrawText("M",132+increase_X, 50, 20, Color.Black);
                        increase_X += 25;
                        break;
                    }
                    case OwnerType.Ai1:
                    {
                        Raylib.DrawRectangle(130+increase_X,200,20,40,monster.Color);
                        Raylib.DrawText("M",132+increase_X, 210, 20, Color.Black);
                        increase_X += 25;
                        break;
                    }
                    case OwnerType.Ai2:
                    {
                        Raylib.DrawRectangle(130+increase_X,360,20,40,monster.Color);
                        Raylib.DrawText("M",132+increase_X, 370, 20, Color.Black);
                        increase_X += 25;
                        break;
                    }
                }
            }
        }
    }
}
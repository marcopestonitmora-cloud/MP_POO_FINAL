using System.Numerics;
using MP_POO_FINAL.Managers;
using Raylib_cs;

namespace MP_POO_FINAL.GameWindow.BoardInfo;

public class TheClassCell : BoardCell
{
    private Random random = new Random();
    public string ActiveMessage { get; private set; } = "";

    public TheClassCell(int index, Vector2 screenPosition, string activeMessage) : base(index, screenPosition)
    {
        ActiveMessage = activeMessage;
    }
    
    public override void OnLand(OwnerType currentPlayer)
    {
        int roll = random.Next(100);

        if (roll < 5)
        {
            FelipeEffect(currentPlayer);
        }
        else if (roll < 28)
        {
            DelegateEffect(currentPlayer);
        }
        else if (roll < 52)
        {
            MarioKartEffect(currentPlayer);
        }
        else if (roll < 76)
        {
            RenfeEffect(currentPlayer);
        }
        else
        {
            PooEffect();
        }
    }

    private void FelipeEffect(OwnerType currentPlayer)
    {
        foreach (BoardCell cell in EventManager.Instance.board.GetAllCells())
        {
            PropertyCell mason = cell as PropertyCell;
            if (mason != null && mason.Index == 27)
            {
                mason.Owner = currentPlayer;
                ActiveMessage = "You tell Felipe a joke\nand he gifts you\nMASON MANSION!";
                return;
            }
        }
    }

    private void DelegateEffect(OwnerType currentPlayer)
    {
        EventManager.Instance.GetCharacter(currentPlayer).LoseInvicions(150);
        ActiveMessage = "The delegate snitched on you\nfor copying the exam,\npay a new enrollment \n-150 invicoins!";
    }

    private void MarioKartEffect(OwnerType currentPlayer)
    {
        EventManager.Instance.GetCharacter(currentPlayer).WinInvicions(100);
        ActiveMessage = "You win a MarioKart tournament,\nyou get 100 invicoins!";
    }

    private void RenfeEffect(OwnerType currentPlayer)
    {
        EventManager.Instance.GetCharacter(currentPlayer).SkippedTurns = 1;
        ActiveMessage = "Renfe is late and you\ncan't make it to class,\nlose a turn!";
    }

    private void PooEffect()
    {
        EventManager.Instance.GetCharacter(OwnerType.Player).WinInvicions(50);
        EventManager.Instance.GetCharacter(OwnerType.Ai1).WinInvicions(50);
        EventManager.Instance.GetCharacter(OwnerType.Ai2).WinInvicions(50);
        ActiveMessage = "POO grades are out,\nsince everyone passes\nyou all get 50 invicoins!";
    }

    public override void DrawOnLandUI()
    {
        if (ActiveMessage == "")
        {
            return;
        }

        int fontSize = 50;
        int textWidth = Raylib.MeasureText(ActiveMessage, fontSize);
        int x = 960 - textWidth / 2;
        int y = 400;

        Raylib.DrawRectangle(x - 20, y - 20, textWidth + 40, 200, Color.Black);
        Raylib.DrawText(ActiveMessage, x, y, fontSize, Color.White);
    }

    public override void Sell(OwnerType currentPlayer) {}
    public override void Buy(OwnerType currentPlayer) {}
}
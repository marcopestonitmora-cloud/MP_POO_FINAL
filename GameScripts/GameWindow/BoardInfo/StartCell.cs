using System.Numerics;
using MP_POO_FINAL.Managers;

namespace MP_POO_FINAL.GameWindow.BoardInfo;

public class StartCell: BoardCell
{
    private int LandBonus { get; set; } = 300;
    private int PassBonus  { get; set; }= 200;

    public StartCell(int index, Vector2 screenPosition, int bonus) : base(index, screenPosition)
    {
        LandBonus = bonus;
    }
    
    // En StartCell
    public override void OnLand(OwnerType currentPlayer)
    {
        // solo se llama cuando caes en start
        EventManager.Instance.GetCharacter(currentPlayer).WinInvicions(LandBonus);
    }

    public void OnPass(OwnerType currentPlayer)
    {
        // se llama desde CellJump cuando pasas por encima
        EventManager.Instance.GetCharacter(currentPlayer).WinInvicions(PassBonus);
    }

    public override void DrawOnLandUI() {}
    public override void Buy(OwnerType currentPlayer) {}
    public override void Sell(OwnerType currentPlayer){}
}
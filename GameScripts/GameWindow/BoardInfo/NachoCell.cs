using System.Numerics;
using MP_POO_FINAL.Managers;

namespace MP_POO_FINAL.GameWindow.BoardInfo;

public class NachoCell: BoardCell
{
    private int NachosBoardPrice {get; set;}

    public NachoCell(int index, Vector2 screenPosition, int nachosBoardPrice) : base(index, screenPosition)
    {
        NachosBoardPrice = nachosBoardPrice;
    }
    
    public override void OnLand(OwnerType currentPlayer)
    {
        EventManager.Instance.GetCharacter(currentPlayer).LoseInvicions(NachosBoardPrice);
    }

    public override void DrawOnLandUI() {}
    public override void Buy(OwnerType currentPlayer) {}
    public override void Sell(OwnerType currentPlayer){}
}
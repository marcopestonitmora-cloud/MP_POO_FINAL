namespace MP_POO_FINAL.GameWindow.Invicoins;

public class Invicoins
{
    public event Action OnBankRuptcy;
    private int amount;
    public int Amount
    {
        get => amount;
        set
        {
            if (value > 999)
            {
                amount = 999;
            }
            else if (value <= 0)
            {
                amount = 0;
                BankRuptcy();
            }
            else
            {
                amount = value;
            }
        }
    }

    protected Invicoins(int amount)
    {
        Amount = amount;
    }

    private void BankRuptcy()
    {
        OnBankRuptcy?.Invoke();
    }
}
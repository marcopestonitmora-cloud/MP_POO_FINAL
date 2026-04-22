namespace MP_POO_FINAL;

public struct CardInfo
{
    private int cardBuyValue;

    public int CardValue
    {
        get => cardBuyValue;
        private set;
    }

    private int creditCounter;

    public int CreditCounter
    {
        get => creditCounter;
        set
        {
            if (value > 6)
            {
                creditCounter = 6;
            }
            else
            {
                creditCounter = value;
            }
        }
    }
    
    private int cardSellValue;

    public int CardSellValue 
    {
        get => cardSellValue;
        private set;
    } 

    public string CardName;
    public string CardColor;
}
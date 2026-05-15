using MP_POO_FINAL.GameWindow.BoardInfo;
using MP_POO_FINAL.GameWindow.Cards.ActionCards;

namespace MP_POO_FINAL.GameWindow.Cards;

public class InitCards
{
    private Board Board;
    
    public InitCards(Board board)
    {
        Board = board;
    }

    public List<Card> CardBuilder()
    {
        return new List<Card>()
        {
            new MoneyCard1("Money","STEAL 25% OF EACH OPPONENT'S INVICIONS",OwnerType.None),
            new MoneyCard1("Money","STEAL 25% OF EACH OPPONENT'S INVICIONS",OwnerType.None),
            
            new MoneyCard2("Money", "GAIN COINS EQUAL TO YOUR CURRENT TILE NUMBER ×10", OwnerType.None),
            new MoneyCard2("Money", "GAIN COINS EQUAL TO YOUR CURRENT TILE NUMBER ×10", OwnerType.None),
            new MoneyCard2("Money", "GAIN COINS EQUAL TO YOUR CURRENT TILE NUMBER ×10", OwnerType.None),
            
            new MoneyCard3("Money","THE RICHEST OPPONENT PAYS YOU 200 COINS",OwnerType.None),
            new MoneyCard3("Money","THE RICHEST OPPONENT PAYS YOU 200 COINS",OwnerType.None),
            
            new MoneyCard4("Money", "ALL PLAYERS LOSE 100 INVICOINS",OwnerType.None),
            new MoneyCard4("Money", "ALL PLAYERS LOSE 100 INVICOINS",OwnerType.None),
            
            new MoneyCard5("Money","COIN FLIP: HEADS DOUBLE YOUR COINS, TAILS LOSE HALF",OwnerType.None),
            new MoneyCard5("Money","COIN FLIP: HEADS DOUBLE YOUR COINS, TAILS LOSE HALF",OwnerType.None),
            
            new PropertyCard1("Property", "STEAL AN OPPONENT'S PROPERTY BY PAYING ONLY 30% OF ITS VALUE", OwnerType.None, Board),
            new PropertyCard1("Property", "STEAL AN OPPONENT'S PROPERTY BY PAYING ONLY 30% OF ITS VALUE", OwnerType.None, Board),
            
            new PropertyCard2("Property", "REMOVE ALL CREDITS FROM ONE OPPONENT’S PROPERTY", OwnerType.None, Board),
            new PropertyCard2("Property", "REMOVE ALL CREDITS FROM ONE OPPONENT’S PROPERTY", OwnerType.None, Board),
            new PropertyCard2("Property", "REMOVE ALL CREDITS FROM ONE OPPONENT’S PROPERTY", OwnerType.None, Board),
            
            new PropertyCard3("Property", "TRIPLE RENT FROM ANY TILE FOR THE REST OF THE GAME", OwnerType.None, Board),
            new PropertyCard3("Property", "TRIPLE RENT FROM ANY TILE FOR THE REST OF THE GAME", OwnerType.None, Board),
            
            new PropertyCard4("Property", "GAIN 2 CREDITS ON ALL YOUR PROPERTIES", OwnerType.None, Board),
            new PropertyCard4("Property", "GAIN 2 CREDITS ON ALL YOUR PROPERTIES", OwnerType.None, Board),
            
            new TurnCard1("Turn", "PLAY AGAIN IMMEDIATELY AFTER YOUR TURN", OwnerType.None),
            new TurnCard1("Turn", "PLAY AGAIN IMMEDIATELY AFTER YOUR TURN", OwnerType.None),
            new TurnCard1("Turn", "PLAY AGAIN IMMEDIATELY AFTER YOUR TURN", OwnerType.None),
            new TurnCard1("Turn", "PLAY AGAIN IMMEDIATELY AFTER YOUR TURN", OwnerType.None),
            
            new TurnCard3("Turn", "TELEPORT TO YOUR MOST EXPENSIVE PROPERTY", OwnerType.None, Board),
        };
    }
}
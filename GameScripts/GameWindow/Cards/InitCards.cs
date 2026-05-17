using MP_POO_FINAL.GameWindow.BoardInfo;
using MP_POO_FINAL.GameWindow.Cards.ActionCards;
using Raylib_cs;

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
            new MoneyCard1("MONEY CARD","STEAL 25% OF EACH\n OPPONENT'S INVICIONS",OwnerType.None, Color.Yellow),
            new MoneyCard1("MONEY CARD","STEAL 25% OF EACH\n OPPONENT'S INVICIONS",OwnerType.None, Color.Yellow),
            
            new MoneyCard2("MONEY CARD", "GAIN COINS EQUAL TO\n YOUR CURRENT TILE\n NUMBER ×10", OwnerType.None, Color.Yellow),
            new MoneyCard2("MONEY CARD", "GAIN COINS EQUAL TO\n YOUR CURRENT TILE\n NUMBER ×10", OwnerType.None, Color.Yellow),
            new MoneyCard2("MONEY CARD", "GAIN COINS EQUAL TO\n YOUR CURRENT TILE\n NUMBER ×10", OwnerType.None, Color.Yellow),
            
            new MoneyCard3("MONEY CARD","THE RICHEST OPPONENT\n PAYS YOU 200 COINS",OwnerType.None, Color.Yellow),
            new MoneyCard3("MONEY CARD","THE RICHEST OPPONENT\n PAYS YOU 200 COINS",OwnerType.None, Color.Yellow),
            
            new MoneyCard4("MONEY CARD", "ALL PLAYERS LOSE\n 100 INVICOINS",OwnerType.None, Color.Yellow),
            new MoneyCard4("MONEY CARD", "ALL PLAYERS LOSE\n 100 INVICOINS",OwnerType.None, Color.Yellow),
            
            new MoneyCard5("MONEY CARD","COIN FLIP: HEADS DOUBLE\n YOUR COINS, TAILS \nLOSE HALF",OwnerType.None, Color.Yellow),
            new MoneyCard5("MONEY CARD","COIN FLIP: HEADS DOUBLE\n YOUR COINS, TAILS \nLOSE HALF",OwnerType.None, Color.Yellow),
            
            new PropertyCard1("PROPERTY CARD", "STEAL AN OPPONENT'S \nPROPERTY BY PAYING ONLY \n30% OF ITS VALUE", OwnerType.None,Color.Blue, Board),
            new PropertyCard1("PROPERTY CARD", "STEAL AN OPPONENT'S \nPROPERTY BY PAYING ONLY \n30% OF ITS VALUE", OwnerType.None,Color.Blue ,Board),
            
            new PropertyCard2("PROPERTY CARD", "REMOVE ALL CREDITS \nFROM ONE OPPONENTS \nPROPERTY", OwnerType.None,Color.Blue, Board),
            new PropertyCard2("PROPERTY CARD", "REMOVE ALL CREDITS \nFROM ONE OPPONENTS \nPROPERTY", OwnerType.None,Color.Blue, Board),
            new PropertyCard2("PROPERTY CARD", "REMOVE ALL CREDITS \nFROM ONE OPPONENTS \nPROPERTY", OwnerType.None,Color.Blue, Board),
            
            new PropertyCard3("PROPERTY CARD", "TRIPLE RENT FROM ANY \nTILE FOR THE REST OF \nTHE GAME", OwnerType.None,Color.Blue, Board),
            new PropertyCard3("PROPERTY CARD", "TRIPLE RENT FROM ANY \nTILE FOR THE REST OF \nTHE GAME", OwnerType.None,Color.Blue, Board),
            
            new PropertyCard4("PROPERTY CARD", "GAIN 2 CREDITS ON \nALL YOUR PROPERTIES", OwnerType.None,Color.Blue, Board),
            new PropertyCard4("PROPERTY CARD", "GAIN 2 CREDITS ON \nALL YOUR PROPERTIES", OwnerType.None,Color.Blue, Board),
            
            new TurnCard1("TURN CARD", "PLAY AGAIN IMMEDIATELY \nAFTER YOUR TURN", OwnerType.None, Color.Green),
            new TurnCard1("TURN CARD", "PLAY AGAIN IMMEDIATELY \nAFTER YOUR TURN", OwnerType.None,Color.Green),
            new TurnCard1("TURN CARD", "PLAY AGAIN IMMEDIATELY \nAFTER YOUR TURN", OwnerType.None,Color.Green),
            new TurnCard1("TURN CARD", "PLAY AGAIN IMMEDIATELY \nAFTER YOUR TURN", OwnerType.None,Color.Green),
            
            new TurnCard3("TURN CARD", "TELEPORT TO YOUR MOST \nEXPENSIVE PROPERTY", OwnerType.None, Board, Color.Green),
            new TurnCard3("TURN CARD", "TELEPORT TO YOUR MOST \nEXPENSIVE PROPERTY", OwnerType.None, Board, Color.Green),
        };
    }
}
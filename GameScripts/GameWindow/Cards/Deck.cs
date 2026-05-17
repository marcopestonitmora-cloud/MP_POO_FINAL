namespace MP_POO_FINAL.GameWindow.Cards;

public class Deck<T>
{
    private Stack<T> cards;
    private List<T> originalCards;
    public IEnumerable<T> GetCards() => cards;

    public Deck(List<T> initialCards)
    {
        originalCards = new List<T>(initialCards);
        Shuffle();
    }

    private void Shuffle()
    {
        Random rnd = new Random();

        List<T> shuffled = originalCards.OrderBy(x => rnd.Next()).ToList();

        cards = new Stack<T>(shuffled);
    }
    
    public T TakeCard()
    {
        if (cards.Count == 0)
        {
            Shuffle(); //Cuando se cogan todas las cartas del mazo se rebaraja y se usa uno nuevo
        }
        
        return cards.Pop();
    }
}
namespace atm;

public class CoinSplitter
{
    public CoinSplitter()
    {
    }

    public virtual List<Money> WithDrawAsList(int money)
    {
        if (money == 0) return new List<Money>();
        var head = TakeWithValue(money);
        var tail = WithDrawAsList(money - head.Value);
        tail.Add(head);
        return tail;
    }

    private Money TakeWithValue(int money)
    {
        return Money.All().First(x => x.Value <= money);
    }
}
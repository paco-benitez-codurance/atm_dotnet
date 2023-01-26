namespace atm;

public class Atm
{
    private Wallet _wallet;
    private bool _infinity;

    private Atm(bool infinity, Wallet wallet)
    {
        _infinity = infinity;
        _wallet = wallet;
    }

    public Wallet WithDraw(int money)
    {
        if (_infinity == false)
        {
            throw new NotEnoughAtmCash();
        }
        var result = WithDrawAsList(money);
        return Wallet.Of(result.ToArray());
    }

    private List<Money> WithDrawAsList(int money)
    {
        if (money == 0) return new List<Money>();
        var head = TakeWithValue(money);
        var tail = WithDrawAsList(money - head.Value);
        tail.Add(head);
        return tail;
    }

    private static Money TakeWithValue(int money)
    {
        return Money.All().First(x => x.Value <= money);
    }

    public static Atm of(Wallet wallet)
    {
        return new Atm(false, wallet);
    }

    public static Atm InfinityWallet()
    {
        return new Atm(true, Wallet.Of(Array.Empty<Money>()));
    }

    public Wallet State()
    {
        return _wallet;
    }
}
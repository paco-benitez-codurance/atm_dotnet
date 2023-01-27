namespace atm;

public class Atm
{
    private readonly AtmState _state;

    private Atm(AtmState state)
    {
        _state = state;
    }

    public Wallet WithDraw(int money)
    {
        if (_state.HasMoney(money) == false)
        {
            throw new NotEnoughAtmCash();
        }
        var result = WithDrawAsList(money);
        return Wallet.Of(result.ToArray());
    }

    private static List<Money> WithDrawAsList(int money)
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

    public static Atm Of(AtmState state)
    {
        return new Atm(state);
    }

    public static Atm InfinityWallet()
    {
        return new Atm(AtmState.InfinityWallet());
    }

    public AtmState State()
    {
        return _state;
    }
}
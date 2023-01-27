namespace atm;

public class Atm
{
    private readonly IAtmState _state;
    private readonly CoinSplitter _coinSplitter;

    private Atm(IAtmState state)
    {
        _state = state;
        _coinSplitter = new CoinSplitter();
    }

    public Wallet WithDraw(int money)
    {
        if (_state.HasMoney(money) == false)
        {
            throw new NotEnoughAtmCash();
        }
        var result = _coinSplitter.WithDrawAsList(money);
        return Wallet.Of(result.ToArray());
    }

    public static Atm Of(IAtmState state)
    {
        return new Atm(state);
    }

    public static Atm InfinityWallet()
    {
        return new Atm(AtmState.InfinityWallet());
    }

    public IAtmState State()
    {
        return _state;
    }
}
namespace atm;

public class Atm
{
    private readonly IAtmState _state;
    private readonly CoinSplitter _coinSplitter;

    private Atm(IAtmState state, CoinSplitter coinSplitter)
    {
        _state = state;
        _coinSplitter = coinSplitter;
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
        return new Atm(state, new CoinSplitter());
    }

    public static Atm InfinityWallet(CoinSplitter? coinSplitter = null)
    {
        return new Atm(AtmState.InfinityWallet(), coinSplitter ?? new CoinSplitter());
    }

    public IAtmState State()
    {
        return _state;
    }
}
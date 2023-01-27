namespace atm;

public class AtmState : IAtmState
{
    private readonly Wallet _wallet;
    private readonly CoinSplitter _coinSplitter;


    private AtmState(Wallet wallet, CoinSplitter coinSplitter)
    {
        _wallet = wallet;
        _coinSplitter = coinSplitter;
    }

    public bool HasMoney(int money)
    {
        var requestedCoins = _coinSplitter.WithDrawAsList(money);
        return _wallet.HasCoins(requestedCoins);
    }

    public static AtmState Of(Wallet wallet, CoinSplitter? coinSpliter = null)
    {
        return new AtmState(wallet, coinSpliter ?? new CoinSplitter());
    }

    public static IAtmState InfinityWallet()
    {
        return new InfinityAtmState();
    }

    public override bool Equals(object? obj)
    {
        var foo = obj as AtmState;
        return foo != null &&
               EqualityComparer<Wallet>.Default.Equals(_wallet, foo._wallet);
    }

    public override int GetHashCode()
    {
        return _wallet.GetHashCode();
    }
}
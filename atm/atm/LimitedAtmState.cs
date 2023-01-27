namespace atm;

public class LimitedAtmState : AtmState
{
    private Wallet _wallet;


    internal LimitedAtmState(Wallet wallet, CoinSplitter coinSplitter) : base(coinSplitter)
    {
        _wallet = wallet;
    }


    public override List<Money> WithDrawAsList(int money)
    {
        return CoinSplitter.WithDrawAsList(money, _wallet.Coins().ToList());
    }

    public override void RemoveFromWallet(List<Money> coins)
    {
        var res = new List<Money>(_wallet.Coins());
        foreach (var coin in coins)
        {
            res.Remove(coin);
        }

        _wallet = Wallet.Of(res.ToArray());
    }


    public override bool Equals(object? obj)
    {
        var foo = obj as LimitedAtmState;
        return foo != null &&
               EqualityComparer<Wallet>.Default.Equals(_wallet, foo._wallet);
    }

    public Wallet CurrentWallet()
    {
        return _wallet;
    }

    public override int GetHashCode()
    {
        return _wallet.GetHashCode();
    }

    public override string ToString()
    {
        var groupBy = _wallet.Coins()
            .GroupBy(c => c.Value)
            .Select(x => x.ToArray().Length + "-" + x.Key);

        return string.Join(", ", groupBy.ToArray());
    }
}
namespace atm;

internal class LimitedAtmState : AtmState
{
    private readonly Wallet _wallet;


    internal LimitedAtmState(Wallet wallet, CoinSplitter coinSplitter): base(coinSplitter)
    {
        _wallet = wallet;
    }

    public override bool HasMoney(int money)
    {
        var requestedCoins = CoinSplitter.WithDrawAsList(money, _wallet.Coins().ToList());
        return _wallet.HasCoins(requestedCoins);
    }
    
    public override List<Money> WithDrawAsList(int money)
    {
        return CoinSplitter.WithDrawAsList(money, _wallet.Coins().ToList());
    }

   

    public override bool Equals(object? obj)
    {
        var foo = obj as LimitedAtmState;
        return foo != null &&
               EqualityComparer<Wallet>.Default.Equals(_wallet, foo._wallet);
    }

    public override int GetHashCode()
    {
        return _wallet.GetHashCode();
    }
}
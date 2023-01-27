namespace atm;

internal class InfinityAtmState : AtmState
{
    internal InfinityAtmState(CoinSplitter coinSplitter) : base(coinSplitter)
    {
    }

    public override List<Money> WithDrawAsList(int money)
    {
        return CoinSplitter.WithDrawAsList(money);
    }

    public override void RemoveFromWallet(List<Money> coins)
    {
    }
}
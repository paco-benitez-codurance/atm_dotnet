namespace atm;

internal class InfinityAtmState : AtmState
{
    internal InfinityAtmState(CoinSplitter coinSplitter) : base(coinSplitter)
    {
    }

    public override bool HasMoney(int money)
    {
        return true;
    }
    
    public override List<Money> WithDrawAsList(int money)
    {
        return CoinSplitter.WithDrawAsList(money);
    }

}
namespace atm;

public abstract class AtmState
{
    protected readonly CoinSplitter CoinSplitter;

    protected AtmState()
    {
    }

    protected AtmState(CoinSplitter coinSplitter)
    {
        CoinSplitter = coinSplitter;
    }

    public abstract bool HasMoney(int money);

    public abstract List<Money> WithDrawAsList(int money);
  

    public static AtmState Of(Wallet wallet, CoinSplitter? coinSpliter = null)
    {
        return new LimitedAtmState(wallet, coinSpliter ?? new CoinSplitter());
    }

    public static AtmState InfinityWallet(CoinSplitter coinSplitter)
    {
        return new InfinityAtmState(coinSplitter);
    }
}
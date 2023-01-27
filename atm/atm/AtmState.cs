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

    public virtual bool HasMoney(int money)
    {
        try
        {
            WithDrawAsList(money);
            return true;
        }
        catch (NotEnoughCoins)
        {
            return false;
        }
    }

    public abstract List<Money> WithDrawAsList(int money);
  

    public static AtmState Of(Wallet wallet, CoinSplitter? coinSplitter = null)
    {
        return new LimitedAtmState(wallet, coinSplitter ?? new CoinSplitter());
    }

    public static AtmState InfinityWallet(CoinSplitter coinSplitter)
    {
        return new InfinityAtmState(coinSplitter);
    }
}
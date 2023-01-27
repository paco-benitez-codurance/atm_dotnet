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
            throw new NotEnoughCoins();
        }
        var result = _state.WithDrawAsList(money);
        _state.RemoveFromWallet(result);
        return Wallet.Of(result.ToArray());
    }

   

    public static Atm Of(AtmState state)
    {
        return new Atm(state);
    }

    public static Atm InfinityWallet(CoinSplitter? coinSplitter = null)
    {
        return new Atm(AtmState.InfinityWallet(coinSplitter ?? new CoinSplitter()));
    }

    public override string ToString()
    {
        return _state.ToString();
    }
}
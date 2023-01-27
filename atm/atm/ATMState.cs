namespace atm;

public class AtmState
{
    private readonly Wallet _wallet;
    private readonly bool _infinity;

    private AtmState(bool infinity, Wallet wallet)
    {
        _wallet = wallet;
        _infinity = infinity;
    }

    public virtual bool HasMoney(int money)
    {
        if (_infinity)
        {
            return true;
        }

        throw new NotImplementedException();
    }

    public static AtmState Of(Wallet wallet)
    {
        return new AtmState(false, wallet);
    }

    public static AtmState InfinityWallet()
    {
        return new AtmState(true, Wallet.Of(Array.Empty<Money>()));
    }

    public override bool Equals(object? obj)
    {
        var foo = obj as AtmState;
        return foo != null &&
               EqualityComparer<Wallet>.Default.Equals(_wallet, foo._wallet) &&
               _infinity == foo._infinity;
    }

    public override int GetHashCode()
    {
        return _wallet.GetHashCode();
    }
}
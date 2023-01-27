namespace atm;

public class AtmState : IAtmState
{
    private readonly Wallet _wallet;


    private AtmState(Wallet wallet)
    {
        _wallet = wallet;
    }

    public bool HasMoney(int money)
    {
        return _wallet.Total() >= money;
    }

    public static AtmState Of(Wallet wallet)
    {
        return new AtmState(wallet);
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
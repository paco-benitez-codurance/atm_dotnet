namespace atm;

public class Wallet
{
    private readonly List<Money> _money;

    private Wallet(List<Money> money)
    {
        _money = money;
    }

    public static Wallet Of(params Money[] money)
    {
        return new Wallet(money.ToList());
    }

    public override string ToString()
    {
        return $"Wallet({_money}";
    }


    public override bool Equals(object? y)
    {
        if (ReferenceEquals(this, y)) return true;
        if (ReferenceEquals(this, null)) return false;
        if (ReferenceEquals(y, null)) return false;
        if (GetType() != y.GetType()) return false;
        return _money.SequenceEqual(((Wallet)y)._money);
    }

    public override int GetHashCode()
    {
        return _money.GetHashCode();
    }
}
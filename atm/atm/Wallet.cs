using System.Collections.Immutable;

namespace atm;

public class Wallet
{
    private readonly ImmutableList<Money> _money;
    
    private Wallet(IEnumerable<Money> money)
    {
        _money = money.ToImmutableList();
    }

    public static Wallet Of(params Money[] money)
    {
        return new Wallet(money.ToList());
    }

    public static Wallet Of(params (int, Money)[] money)
    {
        var res =
            money.SelectMany(x => Enumerable.Repeat(x.Item2, x.Item1));
        return Wallet.Of(res.ToArray());
    }

    public int Total()
    {
        return _money.Select(x => x.Value).Sum();
    }

    public int NumberOfDifferentCoins()
    {
        return _money.Distinct().Count();
    }

    public override string ToString()
    {
        var joined = string.Join(", ", _money.Select(x => x));
        return $"Wallet({joined}";
    }


    public override bool Equals(object? y)
    {
        if (ReferenceEquals(this, y)) return true;
        if (ReferenceEquals(this, null)) return false;
        if (ReferenceEquals(y, null)) return false;
        if (GetType() != y.GetType()) return false;
        var myValues = _money.Sort(Money.Comparer);
        var otherValues = ((Wallet)y)._money.Sort(Money.Comparer);
        return myValues.SequenceEqual(otherValues);
    }

    public override int GetHashCode()
    {
        return _money.GetHashCode();
    }
}
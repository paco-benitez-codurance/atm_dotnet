using System.Collections.Immutable;

namespace atm;

public class Wallet
{
    private readonly ImmutableList<Money> _money;

    public Wallet()
    {
    }

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
        return Of(res.ToArray());
    }

    public virtual bool HasCoins(IEnumerable<Money> coins)
    {
        var clone = new List<Money>(_money);
        return coins.All(coin => clone.Remove(coin));
    }

    public override string ToString()
    {
        var joined = string.Join(", ", _money.Select(x => x));
        return $"Wallet({joined}";
    }


    public override bool Equals(object? obj)
    {
        var foo = obj as Wallet;
        var myValues = _money.Sort(Money.Comparer);
        var otherValues = foo?._money.Sort(Money.Comparer);
        return foo != null &&
               myValues.SequenceEqual(otherValues!);
    }

    public override int GetHashCode()
    {
        return _money.GetHashCode();
    }

    public virtual IEnumerable<Money> Coins()
    {
        return _money;
    }
}
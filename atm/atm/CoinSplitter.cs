using System.Collections.Immutable;

namespace atm;

public class CoinSplitter
{
    private static Money? TakeWithValue(int money, IEnumerable<Money> from)
    {
        return from.FirstOrDefault(x => x.Value <= money, null);
    }

    public virtual List<Money> WithDrawAsList(int money, IEnumerable<Money>? initialCoins = null)
    {
        return _WithDrawAsList(money, initialCoins?.ToImmutableList()).ToList();
    }

    private static ImmutableList<Money> _WithDrawAsList(int money, ImmutableList<Money>? initialCoins = null)
    {
        if (money == 0)
        {
            return ImmutableList<Money>.Empty;
        }
        var head = TakeWithValue(money, initialCoins ?? Money.All());
        if (head == null)
        {
            throw new NotEnoughCoins();
        }
        var tail = _WithDrawAsList(money - head.Value, initialCoins?.Remove(head));

        return tail.Add(head);
    }
}
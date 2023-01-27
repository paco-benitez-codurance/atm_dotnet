using System.Collections.Immutable;

namespace atm;

public class CoinSplitter
{
    public CoinSplitter()
    {
    }

    private Money? TakeWithValue(int money, IEnumerable<Money> from)
    {
        return from.FirstOrDefault(x => x.Value <= money, null);
    }

    public virtual List<Money> WithDrawAsList(int money, List<Money>? initialCoins = null)
    {
        return _WithDrawAsList(money, initialCoins?.ToImmutableList()).ToList();
    }

    private ImmutableList<Money> _WithDrawAsList(int money, ImmutableList<Money>? initialCoins = null)
    {
        var immutableList = initialCoins?.ToImmutableList();
        if (money == 0)
        {
            return ImmutableList<Money>.Empty;
        }
        var head = TakeWithValue(money, immutableList ?? Money.All());
        if (head == null)
        {
            throw new NotEnoughCoins();
        }
        var tail = _WithDrawAsList(money - head.Value, immutableList?.Remove(head));

        return tail.Add(head);
    }
}
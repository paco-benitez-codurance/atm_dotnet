using System.Collections.Immutable;
using atm;

namespace test_atm;

public class CoinSplitterShould
{
    private CoinSplitter _coinSplitter = null!;

    [SetUp]
    public void Setup()
    {
        _coinSplitter = new CoinSplitter();
    }

    [Test]
    public void ReturnEmptyList_when_Zero()
    {
        var actual = _coinSplitter.WithDrawAsList(0);

        var expected = Array.Empty<Money>();
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    [TestCaseSource(nameof(Coins))]
    public void ReturnOneCoin_when_MoneyIsTheValueOfTheCoin(int money, Money coin)
    {
        var actual = _coinSplitter.WithDrawAsList(money);

        var expected = new List<Money> { coin };
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    [TestCase(3)]
    [TestCase(6)]
    [TestCase(7)]
    public void ReturnSum_when_TwoDifferentCoins(int money)
    {
        var actual = _coinSplitter.WithDrawAsList(money);

        Assert.Multiple(() =>
        {
            Assert.That(NumberOfDifferentCoins(actual), Is.EqualTo(2));
            Assert.That(Total(actual), Is.EqualTo(money));
        });
    }

    [Test]
    [TestCase(4)]
    public void ReturnSum_when_SameTwoCoin(int money)
    {
        var actual = _coinSplitter.WithDrawAsList(money);

        Assert.Multiple(() =>
        {
            Assert.That(NumberOfDifferentCoins(actual), Is.EqualTo(1));
            Assert.That(Total(actual), Is.EqualTo(money));
        });
    }

    [Test]
    public void RaiseErrorIfNoCoins()
    {
        const int money = 3;
        var initialCoins = new List<Money>();

        Assert.Throws<NotEnoughCoins>(() =>
            _coinSplitter.WithDrawAsList(money, initialCoins)
        );
    }

    [Test]
    public void NoRaiseErrorIfHasCoins()
    {
        const int money = 3;
        var initialCoins = new List<Money>() { Money.Two, Money.One };

        var actual = _coinSplitter.WithDrawAsList(money, initialCoins);
        Assert.That(
            actual, Is.EquivalentTo(initialCoins)
        );
    }


    private static IEnumerable<TestCaseData> Coins()
    {
        return Money.All().Select(x => new TestCaseData(x.Value, x));
    }

    private static int Total(List<Money> money)
    {
        return money.Select(x => x.Value).Sum();
    }

    private static int NumberOfDifferentCoins(List<Money> money)
    {
        return money.Distinct().Count();
    }
}
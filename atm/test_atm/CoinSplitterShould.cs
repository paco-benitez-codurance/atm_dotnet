using atm;

namespace test_atm;

public class CoinSplitterShould
{
    private CoinSplitter _atm = null!;

    [SetUp]
    public void Setup()
    {
        _atm = new CoinSplitter();
    }

    [Test]
    public void ReturnEmptyList_when_Zero()
    {
        var actual = _atm.WithDrawAsList(0);

        var expected = Array.Empty<Money>();
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    [TestCaseSource(nameof(Coins))]
    public void ReturnOneCoin_when_MoneyIsTheValueOfTheCoin(int money, Money coin)
    {
        var actual = _atm.WithDrawAsList(money);

        var expected = new List<Money> { coin };
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    [TestCase(3)]
    [TestCase(6)]
    [TestCase(7)]
    public void ReturnSum_when_TwoDifferentCoins(int money)
    {
        var actual = _atm.WithDrawAsList(money);

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
        var actual = _atm.WithDrawAsList(money);

        Assert.Multiple(() =>
        {
            Assert.That(NumberOfDifferentCoins(actual), Is.EqualTo(1));
            Assert.That(Total(actual), Is.EqualTo(money));
        });
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
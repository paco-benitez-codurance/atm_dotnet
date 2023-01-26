using atm;

namespace test_atm;

public class AtmShould
{
    Atm atm = null!;

    [SetUp]
    public void Setup()
    {
        atm = new Atm();
    }

    [Test]
    public void ReturnEmptyList_when_Zero()
    {
        var actual = atm.WithDraw(0);

        var expected = Wallet.Of(Array.Empty<Money>());
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    [TestCaseSource(nameof(Coins))]
    public void ReturnOneCoin_when_MoneyIsTheValueOfTheCoin(int money, Money coin)
    {
        var actual = atm.WithDraw(money);

        var expected = Wallet.Of(coin);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    [TestCase(3)]
    [TestCase(6)]
    [TestCase(7)]
    public void ReturnSum_when_TwoDifferentCoins(int money)
    {
        var actual = atm.WithDraw(money);

        Assert.That(actual.NumberOfDifferentCoins(), Is.EqualTo(2));
        Assert.That(actual.Total(), Is.EqualTo(money));
    }

    [Test]
    [TestCase(4)]
    public void ReturnSum_when_SameTwoCoin(int money)
    {
        var actual = atm.WithDraw(money);

        Assert.That(actual.NumberOfDifferentCoins(), Is.EqualTo(1));
        Assert.That(actual.Total(), Is.EqualTo(money));
    }

    [Test]
    public void Return434()
    {
        var actual = atm.WithDraw(434);

        var expected = Wallet.Of(
            (2, Money.Two),
            (1, Money.Ten),
            (1, Money.Twenty),
            (2, Money.TwoHundred)
        );
        Assert.That(actual, Is.EqualTo(expected));
    }


    private static IEnumerable<TestCaseData> Coins()
    {
        return Money.All().Select(x => new TestCaseData(x.Value, x));
    }
}
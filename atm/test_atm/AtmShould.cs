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

        var expected = Wallet.Of();
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    [TestCaseSource(nameof(Coins))]
    public void ReturnOneCoin_when_MoneyIsTheValueOfTheCoin(int money, Money coin)
    {
        var actual = atm.WithDraw(money);

        var expected = Wallet.Of( coin );
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void ReturnTwoAndOneCoin_when_three()
    {
        var actual = atm.WithDraw(3);

        var expected = Wallet.Of( Money.One, Money.Two );
        Assert.That(actual, Is.EqualTo(expected));
    }


    private static IEnumerable<TestCaseData> Coins()
    {
        return Money.All().Select(x => new TestCaseData(x.Value, x));
    }
}
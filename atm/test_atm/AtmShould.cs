using atm;

namespace test_atm;

public class AtmShould
{
    private Atm atm;
    
    [SetUp]
    public void Setup()
    {
        atm = new Atm();
    }

    [Test]
    public void ReturnEmptyList_when_Zero()
    {
        var actual = atm.WithDraw(0);

        var expected = new List<Money>();
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    [TestCaseSource(nameof(Coins))]
    public void ReturnOneCoin_when_MoneyIsTheValueOfTheCoin(int money, Money coin)
    {
        var actual = atm.WithDraw(money);

        var expected = new List<Money>() { coin };
        Assert.That(actual, Is.EqualTo(expected));
    }


    private static IEnumerable<TestCaseData> Coins()
    {
        return Money.AllCoins().Select(x => new TestCaseData(x.Value, x));
    }
}
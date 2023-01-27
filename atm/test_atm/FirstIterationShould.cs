using atm;

namespace test_atm;

public class FirstIterationShould
{
    private Atm _atm = null!;

    [SetUp]
    public void Setup()
    {
        _atm = Atm.InfinityWallet();
    }

    [Test]
    public void WithDraw434()
    {
        var actual = _atm.WithDraw(434);

        var expected = Wallet.Of(
            (2, Money.Two),
            (1, Money.Ten),
            (1, Money.Twenty),
            (2, Money.TwoHundred)
        );
        Assert.That(actual, Is.EqualTo(expected));
    }
}
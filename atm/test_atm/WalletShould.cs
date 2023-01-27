using atm;

namespace test_atm;

public class WalletShould
{
    [Test]
    public void ProvideAWayOfSayTwoCoins()
    {
        var actual = Wallet.Of(Money.One, Money.One);

        var expected = Wallet.Of((2, Money.One));

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void NotConsiderOrder()
    {
        var actual = Wallet.Of(Money.One, Money.Two);

        var expected = Wallet.Of(Money.Two, Money.One);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void HasCoinReturnFalse_If_notEnoughCoins()
    {
        var wallet = Wallet.Of(Money.One, Money.Two);
        var requested = new List<Money> { Money.Twenty };

        Assert.That(wallet.HasCoins(requested), Is.EqualTo(false));
    }
}
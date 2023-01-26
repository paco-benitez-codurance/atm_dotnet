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

}
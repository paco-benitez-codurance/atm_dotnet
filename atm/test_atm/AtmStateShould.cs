using atm;
using Moq;

namespace test_atm;

public class AtmStateShould
{
    [Test]
    public void ReturnFalseIfHasNoCoins()
    {
        const int money = 9;
        var wallet = new Mock<Wallet>();
        var withdraw = new List<Money>() { Money.Five };
        var coinSplitter = ACoinSplitter(money, withdraw);
        wallet.Setup(w => w.HasCoins(withdraw)).Returns(false);
        
        
        var atmState = AtmState.Of(wallet.Object, coinSplitter);

        var actual = atmState.HasMoney(money);
        Assert.That(actual, Is.EqualTo(false));
    }
    
    [Test]
    public void ReturnTrueIfHasCoins()
    {
        const int money = 9;
        var wallet = new Mock<Wallet>();
        var withdraw = new List<Money>() { Money.Five };
        var coinSplitter = ACoinSplitter(money, withdraw);
        wallet.Setup(w => w.HasCoins(withdraw)).Returns(true);
        var atmState = AtmState.Of(wallet.Object, coinSplitter);

        var actual = atmState.HasMoney(money);

        Assert.That(actual, Is.EqualTo(true));
    }
    
    

    private static CoinSplitter ACoinSplitter(int money, List<Money> withdraw)
    {
        var coinSplitter = new Mock<CoinSplitter>();
        coinSplitter.Setup(cs => cs.WithDrawAsList(money, null)).Returns(withdraw);
        return coinSplitter.Object;
    }
}
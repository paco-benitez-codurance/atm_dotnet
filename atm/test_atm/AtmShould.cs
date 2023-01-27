using atm;
using Moq;

namespace test_atm;

public class AtmShould
{
    [Test]
    public void ReturnCoinSplitterList()
    {
        var coinSplitter = new Mock<CoinSplitter>();
        const int money = 33;
        var coins = new List<Money>() { Money.Fifty, Money.One };
        coinSplitter.Setup(cs => cs.WithDrawAsList(money, null)).Returns(coins);

        var atm = Atm.InfinityWallet(coinSplitter.Object);
        var actual = atm.WithDraw(money);

        var expected = Wallet.Of(coins.ToArray());
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void RaiseErrorIfAtmHasNoMoney()
    {
        const int money = 3;
        var atmState = new Mock<AtmState>();
        atmState.Setup(x => x.HasMoney(money)).Returns(false);
        var app = Atm.Of(atmState.Object);

        Assert.Throws<NotEnoughCoins>(() =>
            app.WithDraw(money)
        );
    }

}
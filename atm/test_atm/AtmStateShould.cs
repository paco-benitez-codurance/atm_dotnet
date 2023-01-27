using atm;
using Moq;

namespace test_atm;

public class AtmStateShould
{
    [Test]
    public void ReturnFalseIfHasNoCoins()
    {
        const int money = 9;
        const int notEnoughMoney = 8;
        var atmState = AnAtmState(notEnoughMoney);

        var actual = atmState.HasMoney(money);

        Assert.That(actual, Is.EqualTo(false));
    }


    [Test]
    public void ReturnTrueIfHasCoins()
    {
        const int money = 10;
        const int enoughMoney = 10;
        var atmState = AnAtmState(enoughMoney);

        var actual = atmState.HasMoney(money);

        Assert.That(actual, Is.EqualTo(true));
    }
    
    private static AtmState AnAtmState(int notEnoughMoney)
    {
        var wallet = new Mock<Wallet>();
        wallet.Setup(w => w.Total()).Returns(notEnoughMoney);
        var atmState = atm.AtmState.Of(wallet.Object);
        return atmState;
    }
}
using atm;
using Moq;

namespace test_atm;

public class AtmStateShould
{
    [Test]
    public void ReturnFalseIfHasNoMoney()
    {
        const int money = 9;
        const int notEnoughMoney = 8;
        var atmState = AtmState(notEnoughMoney);

        var actual = atmState.HasMoney(money);

        Assert.That(actual, Is.EqualTo(false));
    }


    [Test]
    public void ReturnTrueIfHasMoney()
    {
        const int money = 9;
        const int enoughMoney = 9;
        var atmState = AtmState(enoughMoney);

        var actual = atmState.HasMoney(money);

        Assert.That(actual, Is.EqualTo(true));
    }

    private static AtmState AtmState(int notEnoughMoney)
    {
        var wallet = new Mock<Wallet>();
        wallet.Setup(w => w.Total()).Returns(notEnoughMoney);
        var atmState = atm.AtmState.Of(wallet.Object);
        return atmState;
    }
}
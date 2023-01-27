using atm;
using Moq;

namespace test_atm;

public class SecondIterationAtmShould
{
    [Test]
    public void ProvideAWayToGiveInitialState()
    {
        var wallet = AWallet();
        var app = NewAtm(AtmState.Of(wallet));

        Assert.That(app.State(), Is.EqualTo(AtmState.Of(wallet)));
    }


    [Test]
    public void RaiseErrorIfAtmHasNoMoney()
    {
        const int money = 3;
        var atmState = new Mock<AtmState>();
        atmState.Setup(x => x.HasMoney(money)).Returns(false);
        var app = NewAtm(atmState.Object);

        Assert.Throws<NotEnoughAtmCash>(() =>
            app.WithDraw(money)
        );
    }

    private static Atm NewAtm(AtmState atmState)
    {
        return Atm.Of(atmState);
    }

    private static Wallet AWallet()
    {
        return Wallet.Of((1, Money.Fifty), (2, Money.Twenty));
    }
}
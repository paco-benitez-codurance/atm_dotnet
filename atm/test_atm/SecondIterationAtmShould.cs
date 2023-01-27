using atm;

namespace test_atm;

public class SecondIterationAtmShould
{
    [Test]
    public void RaiseErrorIfAtmHasNoMoney()
    {
        const int money = 3;
        var app = Atm.Of(AtmState.Of(AWallet()));

        Assert.Throws<NotEnoughCoins>(() =>
            app.WithDraw(money)
        );
    }

    [Test]
    public void NotRaiseErrorIfAtmCanGiveAnotherSmallCoins()
    {
        const int money = 2;
        var wallet = Wallet.Of((2, Money.One));
        var app = Atm.Of(AtmState.Of(wallet));

        Assert.That(app.WithDraw(money), Is.EqualTo(wallet));
    }

    private static Wallet AWallet()
    {
        return Wallet.Of((1, Money.Fifty), (2, Money.Twenty));
    }
}
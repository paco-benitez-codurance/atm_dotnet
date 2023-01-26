using atm;

namespace test_atm;

public class SecondIterationAtmShould
{
    [Test]
    public void ProvideAWayToGiveInitialState()
    {
        var wallet = AWallet();
        var app = Atm.of(wallet);

        Assert.That(app.State(), Is.EqualTo(wallet));
    }

    [Test]
    public void RaiseErrorIfAtmWalletIsEmpty()
    {
        var wallet = AnEmptyWallet();
        var money = 3;
        var app = Atm.of(wallet);

        Assert.Throws<NotEnoughAtmCash>(() =>
            app.WithDraw(money)
        );
    }

    private static Wallet AnEmptyWallet()
    {
        return Wallet.Of(Array.Empty<Money>());
    }

    private static Wallet AWallet()
    {
        return Wallet.Of((1, Money.Fifty), (2, Money.Twenty));
    }
}
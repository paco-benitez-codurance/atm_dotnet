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

    [Test]
    public void WithDraw1725()
    {
        var app = Atm.Of(AtmState.Of(Wallet.Of(
            (2, Money.FiveHundred),
            (3, Money.TwoHundred),
            (5, Money.OneHundred),
            (12, Money.Fifty),
            (20, Money.Twenty),
            (50, Money.Ten),
            (100, Money.Five),
            (250, Money.Two),
            (500, Money.One)
        )));

        var actual = app.WithDraw(1725);
        
        var expected = Wallet.Of(
            (2, Money.FiveHundred),
            (3, Money.TwoHundred),
            (1, Money.OneHundred),
            (1, Money.Twenty),
            (1, Money.Five)
        );
        Assert.That(actual.Coins(), Is.EquivalentTo(expected.Coins()));
    }
    
    [Test]
    public void WithDraw1725And1825()
    {
        var app = Atm.Of(AtmState.Of(Wallet.Of(
            (2, Money.FiveHundred),
            (3, Money.TwoHundred),
            (5, Money.OneHundred),
            (12, Money.Fifty),
            (20, Money.Twenty),
            (50, Money.Ten),
            (100, Money.Five),
            (250, Money.Two),
            (500, Money.One)
        )));

        var actual = app.WithDraw(1725);
        
        var expected = Wallet.Of(
            (2, Money.FiveHundred),
            (3, Money.TwoHundred),
            (1, Money.OneHundred),
            (1, Money.Twenty),
            (1, Money.Five)
        );
        
        Assert.That(actual.Coins(), Is.EquivalentTo(expected.Coins()));
        
        var secondWithDraw = app.WithDraw(1825);
        
        var secondExpected = Wallet.Of(
            (4, Money.OneHundred),
            (12, Money.Fifty),
            (19, Money.Twenty),
            (44, Money.Ten),
            (1, Money.Five)
        );
        
        Assert.That(secondWithDraw.Coins(), Is.EquivalentTo(secondExpected.Coins()));
    }

    private static Wallet AWallet()
    {
        return Wallet.Of((1, Money.Fifty), (2, Money.Twenty));
    }
}
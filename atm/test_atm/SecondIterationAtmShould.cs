using atm;
using Moq;

namespace test_atm;

public class SecondIterationAtmShould
{
    
    [Test]
    public void RaiseErrorIfAtmHasNoMoney()
    {
        const int money = 3;
        var app = Atm.Of(AtmState.Of(AWallet()));

        Assert.Throws<NotEnoughAtmCash>(() =>
            app.WithDraw(money)
        );
    }
    private static Wallet AWallet()
    {
        return Wallet.Of((1, Money.Fifty), (2, Money.Twenty));
    }
}
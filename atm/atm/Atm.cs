namespace atm;

public class Atm
{
    public Wallet WithDraw(int money)
    {
        if (money == 0)
        {
            return Wallet.Of();
        }

        var exactMoney = ExactMoney(money);
        if (exactMoney != null)
        {
            return Wallet.Of(exactMoney);
        }

        return Wallet.Of(Money.One, Money.Two);
    }

    private static Money? ExactMoney(int money)
    {
        return Money
            .All()
            .FirstOrDefault(x => x.Value == money);
    }
}
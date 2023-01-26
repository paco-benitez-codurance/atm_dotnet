namespace atm;

public class Atm
{
    public List<Money> WithDraw(int money)
    {
        return Money.AllCoins()
            .Where(x => x.Value == money)
            .ToList();
    }
}
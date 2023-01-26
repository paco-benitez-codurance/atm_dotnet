namespace atm;

public class Atm
{
    public List<Money> WithDraw(int money)
    {
        return money switch
        {
            1 => new List<Money>() { Money.OneCoin },
            _ => new List<Money>()
        };
    }
}
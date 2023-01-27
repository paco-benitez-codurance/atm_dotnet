namespace atm;

public class InfinityAtmState : IAtmState
{
    public bool HasMoney(int money)
    {
        return true;
    }
}
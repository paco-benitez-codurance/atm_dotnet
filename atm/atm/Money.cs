namespace atm;

public class Money
{
    public int Value { get; }
    
    private static readonly Money One = new(1);
    private static readonly Money Two = new(2);
    private static readonly Money Five = new(5);

    private Money(int value)
    {
        Value = value;
    }

    public static IEnumerable<Money> AllCoins()
    {
        return new List<Money>()
        {
            One,
            Two,
            Five
        };
    }
}
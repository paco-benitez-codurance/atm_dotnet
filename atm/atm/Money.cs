namespace atm;

public sealed record Money(int Value)
{

    public static readonly Money One = new(1);
    public static readonly Money Two = new(2);
    private static readonly Money Five = new(5);


    public static IEnumerable<Money> All()
    {
        return new List<Money>()
        {
            One,
            Two,
            Five
        };
    }
}
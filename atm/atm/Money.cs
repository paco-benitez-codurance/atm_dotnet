namespace atm;

public sealed record Money(int Value)
{
    public static readonly Money One = new(1);
    public static readonly Money Two = new(2);
    public static readonly Money Five = new(5);
    public static readonly Money Ten = new(10);
    public static readonly Money Twenty = new(20);
    public static readonly Money Fifty = new(50);
    public static readonly Money OneHundred = new(100);
    public static readonly Money TwoHundred = new(200);
    public static readonly Money FiveHundred = new(500);


    public static IEnumerable<Money> All()
    {
        return new List<Money>()
        {
            FiveHundred,
            TwoHundred,
            OneHundred,
            Fifty,
            Twenty,
            Ten,
            Five,
            Two,
            One
        };
    }
}
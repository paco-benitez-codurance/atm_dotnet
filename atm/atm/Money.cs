using System.Collections;

namespace atm;

public class Money
{
    public readonly int Value;
    
    private Money(int value)
    {
        this.Value = value;
    }


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

    public static IComparer<Money> Comparer = new MoneyComparer();

    private class MoneyComparer : IComparer<Money>
    {
        public int Compare(Money? x, Money? y)
        {
            return x!.Value.CompareTo(y!.Value);
        }
    }
        

}
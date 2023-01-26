using atm;

namespace test_atm;

public class AtmShould
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ReturnEmptyList_when_Zero()
    {
        var atm = new Atm();

        var actual = atm.WithDraw(0);

        var expected = new List<Money>();
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void ReturnOneCoinOfOne_when_One()
    {
        var atm = new Atm();

        var actual = atm.WithDraw(1);

        var expected = new List<Money>() { Money.OneCoin };
        Assert.That(actual, Is.EqualTo(expected));
    }
}
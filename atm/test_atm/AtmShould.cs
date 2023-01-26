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
        var atm = new Atm<string>();

        var actual = atm.WithDraw(0);

        var expected = new List<string>();
        Assert.That(actual, Is.EqualTo(expected));
    }
}
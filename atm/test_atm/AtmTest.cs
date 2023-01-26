using atm;

namespace test_atm;

public class AtmTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestWorks()
    {
        var atm = new Atm();

        var actual = atm.Hi();
        
        const string expected = "hi";
        Assert.That(actual, Is.EqualTo(expected));
    }
}
using Library;

namespace Library.Tests;

public class OrLogicGateTests
{
    private AndLogicGate _andLogicGate;
    
    [SetUp]
    public void Setup()
    {
        _andLogicGate = new AndLogicGate("AND-1");
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}
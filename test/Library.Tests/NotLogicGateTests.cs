namespace Library.Tests;

[TestFixture]
public class NotLogicGateTests
{
    private NotLogicGate _notLogicGate;
    private TrueLogicGate _trueLogicGate;
    private FalseLogicGate _falseLogicGate;

    [SetUp]
    public void SetUp()
    {
        _notLogicGate = new NotLogicGate("NOT-1");
        _trueLogicGate = new TrueLogicGate();
        _falseLogicGate = new FalseLogicGate();
    }

    [Test]
    public void ConstructorNotLogicGate_ValidParameters_CreatedClassSuccessfully()
    {
        string expectedName = "NOT-2";

        NotLogicGate notLogicGate = new NotLogicGate("NOT-2");

        string actualName = notLogicGate.Name;

        Assert.AreEqual(expectedName, actualName);
        Assert.IsNull(notLogicGate.Input);
    }

    [Test]
    public void GetAndSetInput_ValidInput_AssignedCorrectInput()
    {
        ILogicGate expectedInput = _trueLogicGate;
        
        _notLogicGate.Input = _trueLogicGate;

        ILogicGate actualInput = _notLogicGate.Input;
        
        Assert.AreEqual(expectedInput, actualInput);
    }

    [Test]
    [TestCase(0, 1)]
    [TestCase(1, 0)]
    public void EvaluateExpression_ValidCasesNotTruthTable_ReturnsExpectedValues(int input1, int expectedResult)
    {
        ILogicGate newInput1 = input1 == 0 ? _falseLogicGate : _trueLogicGate;
        _notLogicGate.Input = newInput1;

        int obtainedResult = _notLogicGate.EvaluateExpression();
        
        Assert.AreEqual(expectedResult, obtainedResult);
    }
}
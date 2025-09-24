using Library;

namespace Library.Tests;

[TestFixture]
public class AndLogicGateTests
{
    private AndLogicGate _andLogicGate;
    private TrueLogicGate _trueLogicGate;
    private FalseLogicGate _falseLogicGate;

    [SetUp]
    public void SetUp()
    {
        _andLogicGate = new AndLogicGate("AND-1");
        _trueLogicGate = new TrueLogicGate();
        _falseLogicGate = new FalseLogicGate();
    }

    [Test]
    public void ConstructorAndLogicGate_ValidParameters_CreatedClassSuccessfully()
    {
        string expectedName = "AND-2";
        int expectedInputsElementsCount = 0;

        AndLogicGate andLogicGate = new AndLogicGate("AND-2");

        string actualName = andLogicGate.Name;
        List<ILogicGate> actualListOfInputs = andLogicGate.Inputs;
        int actualInputsElementsCount = actualListOfInputs.Count;

        Assert.AreEqual(expectedName, actualName);
        Assert.IsEmpty(actualListOfInputs);
        Assert.AreEqual(expectedInputsElementsCount, actualInputsElementsCount);
    }

    [Test]
    public void AddInput_ValidInput_AddedInputToTheListOfInputsCorrectly()
    {
        int expectedListElementsCount = 1;

        _andLogicGate.AddInput(_falseLogicGate);

        List<ILogicGate> actualInputs = _andLogicGate.Inputs;
        int actualListElementsCount = actualInputs.Count;

        Assert.IsNotEmpty(actualInputs);
        Assert.AreEqual(expectedListElementsCount, actualListElementsCount);
        Assert.Contains(_falseLogicGate, actualInputs);
    }

    [Test]
    public void RemoveInput_ValidInput_RemovedInputOfTheListOfInputsCorrectly()
    {
        int expectedListElementsCount = 0;
        _andLogicGate.AddInput(_trueLogicGate);

        _andLogicGate.RemoveInput(_trueLogicGate);

        List<ILogicGate> actualListOfInputs = _andLogicGate.Inputs;
        int actualListElementsCount = actualListOfInputs.Count;

        Assert.IsEmpty(actualListOfInputs);
        Assert.AreEqual(expectedListElementsCount, actualListElementsCount);
    }

    [Test]
    public void RemoveInput_InputNotInList_DoesNothing()
    {
        _andLogicGate.RemoveInput(_trueLogicGate);
        
        Assert.IsEmpty(_andLogicGate.Inputs);
    }

    [Test]
    [TestCase(0, 0, 0)]
    [TestCase(0, 1, 0)]
    [TestCase(1, 0, 0)]
    [TestCase(1, 1, 1)]
    public void EvaluateExpression_ValidCasesAndTruthTableWithTwoInputs_ReturnsExpectedValues(
        int input1,
        int input2,
        int expectedResult
    )
    {
        ILogicGate newInput1 = input1 == 0 ? _falseLogicGate : _trueLogicGate;
        ILogicGate newInput2 = input2 == 0 ? _falseLogicGate : _trueLogicGate;
        _andLogicGate.AddInput(newInput1);
        _andLogicGate.AddInput(newInput2);

        int obtainedResult = _andLogicGate.EvaluateExpression();

        Assert.AreEqual(expectedResult, obtainedResult);
    }

    [Test]
    [TestCase(0, 0, 0, 0)]
    [TestCase(0, 0, 1, 0)]
    [TestCase(0, 1, 0, 0)]
    [TestCase(0, 1, 1, 0)]
    [TestCase(1, 0, 0, 0)]
    [TestCase(1, 0, 1, 0)]
    [TestCase(1, 1, 0, 0)]
    [TestCase(1, 1, 1, 1)]
    
    public void EvaluateExpression_ValidCasesAndTruthTableWithThreeInputs_ReturnsExpectedValues(
        int input1,
        int input2,
        int input3,
        int expectedResult
    )
    {
        ILogicGate newInput1 = input1 == 0 ? _falseLogicGate : _trueLogicGate;
        ILogicGate newInput2 = input2 == 0 ? _falseLogicGate : _trueLogicGate;
        ILogicGate newInput3 = input3 == 0 ? _falseLogicGate : _trueLogicGate;
        _andLogicGate.AddInput(newInput1);
        _andLogicGate.AddInput(newInput2);
        _andLogicGate.AddInput(newInput3);

        int obtainedResult = _andLogicGate.EvaluateExpression();
        
        Assert.AreEqual(expectedResult, obtainedResult);
    }
}
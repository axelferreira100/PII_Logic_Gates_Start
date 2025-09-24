using Library;

namespace Library.Tests;

[TestFixture]
public class OrLogicGateTests
{
    private OrLogicGate _orLogicGate;
    private TrueLogicGate _trueLogicGate;
    private FalseLogicGate _falseLogicGate;

    [SetUp]
    public void SetUp()
    {
        _orLogicGate = new OrLogicGate("OR-1");
        _trueLogicGate = new TrueLogicGate();
        _falseLogicGate = new FalseLogicGate();
    }

    [Test]
    public void ConstructorOrLogicGate_ValidParameters_CreatedClassSuccessfully()
    {
        string expectedName = "OR-2";
        int expectedInputsElementsCount = 0;

        OrLogicGate orLogicGate = new OrLogicGate("OR-2");

        string actualName = orLogicGate.Name;
        List<ILogicGate> actualListOfInputs = orLogicGate.Inputs;
        int actualInputsElementsCount = actualListOfInputs.Count;

        Assert.AreEqual(expectedName, actualName);
        Assert.IsEmpty(actualListOfInputs);
        Assert.AreEqual(expectedInputsElementsCount, actualInputsElementsCount);
    }

    [Test]
    public void AddInput_ValidInput_AddedInputToTheListOfInputsCorrectly()
    {
        int expectedListElementsCount = 1;

        _orLogicGate.AddInput(_falseLogicGate);

        List<ILogicGate> actualInputs = _orLogicGate.Inputs;
        int actualListElementsCount = actualInputs.Count;

        Assert.IsNotEmpty(actualInputs);
        Assert.AreEqual(expectedListElementsCount, actualListElementsCount);
        Assert.Contains(_falseLogicGate, actualInputs);
    }

    [Test]
    public void RemoveInput_ValidInput_RemovedInputOfTheListOfInputsCorrectly()
    {
        int expectedListElementsCount = 0;
        _orLogicGate.AddInput(_trueLogicGate);

        _orLogicGate.RemoveInput(_trueLogicGate);

        List<ILogicGate> actualListOfInputs = _orLogicGate.Inputs;
        int actualListElementsCount = actualListOfInputs.Count;

        Assert.IsEmpty(actualListOfInputs);
        Assert.AreEqual(expectedListElementsCount, actualListElementsCount);
    }

    [Test]
    public void RemoveInput_InputNotInList_DoesNothing()
    {
        _orLogicGate.RemoveInput(_trueLogicGate);
        
        Assert.IsEmpty(_orLogicGate.Inputs);
    }

    [Test]
    [TestCase(0, 0, 0)]
    [TestCase(0, 1, 1)]
    [TestCase(1, 0, 1)]
    [TestCase(1, 1, 1)]
    public void EvaluateExpression_ValidCasesOrTruthTableWithTwoInputs_ReturnsExpectedValues(
        int input1,
        int input2,
        int expectedResult
    )
    {
        ILogicGate newInput1 = input1 == 0 ? _falseLogicGate : _trueLogicGate;
        ILogicGate newInput2 = input2 == 0 ? _falseLogicGate : _trueLogicGate;
        _orLogicGate.AddInput(newInput1);
        _orLogicGate.AddInput(newInput2);

        int obtainedResult = _orLogicGate.EvaluateExpression();

        Assert.AreEqual(expectedResult, obtainedResult);
    }

    [Test]
    [TestCase(0, 0, 0, 0)]
    [TestCase(0, 0, 1, 1)]
    [TestCase(0, 1, 0, 1)]
    [TestCase(0, 1, 1, 1)]
    [TestCase(1, 0, 0, 1)]
    [TestCase(1, 0, 1, 1)]
    [TestCase(1, 1, 0, 1)]
    [TestCase(1, 1, 1, 1)]
    
    public void EvaluateExpression_ValidCasesOrTruthTableWithThreeInputs_ReturnsExpectedValues(
        int input1,
        int input2,
        int input3,
        int expectedResult
    )
    {
        ILogicGate newInput1 = input1 == 0 ? _falseLogicGate : _trueLogicGate;
        ILogicGate newInput2 = input2 == 0 ? _falseLogicGate : _trueLogicGate;
        ILogicGate newInput3 = input3 == 0 ? _falseLogicGate : _trueLogicGate;
        _orLogicGate.AddInput(newInput1);
        _orLogicGate.AddInput(newInput2);
        _orLogicGate.AddInput(newInput3);

        int obtainedResult = _orLogicGate.EvaluateExpression();
        
        Assert.AreEqual(expectedResult, obtainedResult);
    }
}
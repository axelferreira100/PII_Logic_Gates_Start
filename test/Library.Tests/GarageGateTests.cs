namespace Library.Tests;

[TestFixture]
public class GarageGateTests
{
    private GarageGate _garageGate;
    private TrueLogicGate _trueLogicGate;
    private FalseLogicGate _falseLogicGate;

    [SetUp]
    public void SetUp()
    {
        _garageGate = new GarageGate("Garage-Gate-1");
        _trueLogicGate = new TrueLogicGate();
        _falseLogicGate = new FalseLogicGate();
    }

    [Test]
    public void ConstructorGarageGate_ValidParameters_CreatedClassSuccessfully()
    {
        string expectedName = "Garage-Gate-2";
        ILogicGate[] expectedNewListOfInputs = new ILogicGate[3];

        GarageGate garageGate = new GarageGate("Garage-Gate-2");

        string actualName = garageGate.Name;
        ILogicGate[] actualListOfInputs = garageGate.Inputs;
        
        Assert.AreEqual(expectedName, actualName);
        Assert.AreEqual(expectedNewListOfInputs, actualListOfInputs);
    }

    [Test]
    public void GetAndSetInputs_ValidListOfInputs_AssignedCorrectInputs()
    {
        ILogicGate[] expectedListOfInputs = [_trueLogicGate, _falseLogicGate, _trueLogicGate];
        int expectedCantityOfElementsInListOfInputs = expectedListOfInputs.Length;
        
        _garageGate.Inputs = [_trueLogicGate, _falseLogicGate, _trueLogicGate];

        ILogicGate[] actualListOfInputs = _garageGate.Inputs;
        int actualCantityOfElementsInListOfInputs = actualListOfInputs.Length;

        Assert.IsNotEmpty(actualListOfInputs);
        Assert.AreEqual(expectedCantityOfElementsInListOfInputs, actualCantityOfElementsInListOfInputs);
        Assert.AreEqual(expectedListOfInputs, actualListOfInputs);
    }
    
    [Test]
    [TestCase(0, 0, 0, 0)]
    [TestCase(0, 0, 1, 0)]
    [TestCase(0, 1, 0, 0)]
    [TestCase(0, 1, 1, 0)]
    [TestCase(1, 0, 0, 1)]
    [TestCase(1, 0, 1, 0)]
    [TestCase(1, 1, 0, 0)]
    [TestCase(1, 1, 1, 1)]
    public void EvaluateExpression_ValidCasesGarageGateTruthTable_ReturnsExpectedValues(
        int inputC,
        int inputA,
        int inputB,
        int expectedResult
    )
    {
        ILogicGate newInputA = inputA == 0 ? _falseLogicGate : _trueLogicGate;
        ILogicGate newInputB = inputB == 0 ? _falseLogicGate : _trueLogicGate;
        ILogicGate newInputC = inputC == 0 ? _falseLogicGate : _trueLogicGate;
        _garageGate.Inputs = [newInputA, newInputB, newInputC];

        int obtainedResult = _garageGate.EvaluateExpression();

        Assert.AreEqual(expectedResult, obtainedResult);
    }
}
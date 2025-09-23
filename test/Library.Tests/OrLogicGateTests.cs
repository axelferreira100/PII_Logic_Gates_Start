using Library;

namespace Library.Tests;

public class OrLogicGateTests
{
    private OrLogicGate _orLogicGate;
    
    [SetUp]
    public void Setup()
    {
        _orLogicGate = new OrLogicGate("OR-1");
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
        
        FalseLogicGate falseLogicGate = new FalseLogicGate();
        _orLogicGate.AddInput(falseLogicGate);

        List<ILogicGate> actualInputs = _orLogicGate.Inputs;
        int actualListElementsCount = actualInputs.Count;
                
        Assert.IsNotEmpty(actualInputs);
        Assert.AreEqual(expectedListElementsCount, actualListElementsCount);
        Assert.Contains(falseLogicGate, actualInputs);
    }
}
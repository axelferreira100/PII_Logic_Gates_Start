namespace Library;

public class GarageGate : ILogicGate
{
    private string name;
    private ILogicGate[] inputs;

    public string Name
    {
        get { return this.name; }
        private set { this.name = value; }
    }

    public ILogicGate[] Inputs
    {
        get { return this.inputs; }
        set { this.inputs = value; }
    }

    public GarageGate(string name)
    {
        this.Name = name;
        this.Inputs = new ILogicGate[3]; // A (1) - B (2) - C (3)
    }

    public int EvaluateExpression()
    {
        ILogicGate inputA = Inputs[0], inputB = Inputs[1], inputC = Inputs[2];
        
        NotLogicGate negativeInputA = new NotLogicGate("NOT-A");
        NotLogicGate negativeInputB = new NotLogicGate("NOT-B");
        
        AndLogicGate positivesABAndLogicGate = new AndLogicGate("AND-1");
        AndLogicGate negativesABAndLogicGate = new AndLogicGate("AND-2");
        AndLogicGate finalAndLogicGate = new AndLogicGate("AND-3");
        
        OrLogicGate orLogicGate = new OrLogicGate("OR-1");

        negativeInputA.Input = inputA;
        negativeInputB.Input = inputB;
        
        positivesABAndLogicGate.AddInput(inputA);
        positivesABAndLogicGate.AddInput(inputB);
        negativesABAndLogicGate.AddInput(negativeInputA);
        negativesABAndLogicGate.AddInput(negativeInputB);
        
        orLogicGate.AddInput(positivesABAndLogicGate);
        orLogicGate.AddInput(negativesABAndLogicGate);
        
        finalAndLogicGate.AddInput(orLogicGate);
        finalAndLogicGate.AddInput(inputC);

        return finalAndLogicGate.EvaluateExpression();
    }
}
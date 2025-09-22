namespace Library;

public class AndLogicGate : ILogicGate
{
    private string name;
    private List<ILogicGate> inputs;
        
    public string Name
    {
        get { return this.name; }
        private set { this.name = value; }
    }

    public List<ILogicGate> Inputs
    {
        get { return this.inputs; }
        set { this.inputs = value; }
    }

    public AndLogicGate(string name)
    {
        this.Name = name;
        this.Inputs = new List<ILogicGate>();
    }

    public void AddInput(ILogicGate input)
    {
        this.Inputs.Add(input);
    }

    public void RemoveInput(ILogicGate input)
    {
        this.Inputs.Remove(input);
    }

    public int EvaluateExpression()
    {
        foreach (ILogicGate logicalExpression in this.Inputs)
        {
            if (logicalExpression.EvaluateExpression() == 0)
            {
                return 0;
            }
        }

        return 1;
    }
}
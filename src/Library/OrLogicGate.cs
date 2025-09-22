namespace Library;

public class OrLogicGate : ILogicGate
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

    public OrLogicGate(string name)
    {
        this.Name = name;
        this.Inputs = new List<int>();
    }
    
    public void AddInput(int input)
    {
        this.Inputs.Add(input);
    }

    public void RemoveInput(int input)
    {
        this.Inputs.Remove(input);
    }

    public int EvaluateExpression()
    {
        foreach (ILogicGate logicalExpression in this.Inputs)
        {
            if (logicalExpression.EvaluateExpression() == 1)
            {
                return 1;
            }
        }

        return 0;
    }
}
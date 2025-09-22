namespace Library;

public class AndLogicGate
{
    private string name;
    private List<int> inputs;
    private int resultValue;
        
    public string Name
    {
        get { return this.name; }
        private set { this.name = value; }
    }

    public List<int> Inputs
    {
        get { return this.inputs; }
        set { this.inputs = value; }
    }

    public int ResultValue
    {
        get { return this.resultValue; }
        private set { this.resultValue = value; }
    }

    public AndLogicGate(string name)
    {
        this.Name = name;
        this.Inputs = new List<int>();
        this.ResultValue = 0;
    }

    public void AddInput(int input)
    {
        this.Inputs.Add(input);
    }

    public void EvaluateExpression()
    {
        if (this.Inputs.Contains(0))
        {
            this.ResultValue = 0;
        }
        else
        {
            this.ResultValue = 1;
        }
    }
}
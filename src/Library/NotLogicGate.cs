namespace Library;

public class NotLogicGate : ILogicGate
{
    private string name;
    private ILogicGate input;
        
    public string Name
    {
        get { return this.name; }
        private set { this.name = value; }
    }

    public ILogicGate Input
    {
        get { return this.input; }
        set { this.input = value; }
    }

    public NotLogicGate(string name)
    {
        this.Name = name;
    }

    public int EvaluateExpression()
    {
        if (this.input.EvaluateExpression() == 0)
        {
            return 1;
        }

        return 0;
    }
}
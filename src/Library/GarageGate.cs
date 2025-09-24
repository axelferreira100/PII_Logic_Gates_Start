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
        if (this.Inputs[2].EvaluateExpression() == 1)
        {
            if (!this.Inputs.Contains<>(0))
            {
                return 1;
            }

            if (this.Inputs[0].EvaluateExpression() == 0 && this.Inputs[1].EvaluateExpression() == 0)
            {
                return 1;
            }
        }

        return 0;
    }
}
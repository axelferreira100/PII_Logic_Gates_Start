namespace Library;

public class NotLogicGate
{
    private string name;
    private int input, resultValue;
        
    public string Name
    {
        get { return this.name; }
        private set { this.name = value; }
    }

    public int Input
    {
        get { return this.input; }
        set { this.input = value; }
    }

    public int ResultValue
    {
        get { return this.resultValue; }
        private set { this.resultValue = value; }
    }

    public void EvaluateExpression()
    {
        if (this.Input == 0)
        {
            this.ResultValue = 1;
        }
        else
        {
            this.ResultValue = 0;
        }
    }
}
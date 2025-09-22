namespace Library;

public class NotLogicGate
{
    private string name;
    private int input;
    private int resultValue;
        
    public string Name
    {
        get { return this.name; }
        private set { this.name = value; }
    }

    public int Inputs
    {
        get { return this.input; }
        set { this.input = value; }
    }

    public int ResultValue
    {
        get { return this.resultValue; }
        private set { this.resultValue = value; }
    }
}
namespace Library;

public class OrLogicGate
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
}
public class OutputPort<T> : Port, IOutput
{
    private readonly T _value;

    protected OutputPort(T value)
    {
        _value = value;
    }
}
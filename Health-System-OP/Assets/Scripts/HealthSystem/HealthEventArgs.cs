public struct HealthEventArgs
{
    public float current;
    public float max;
    public float delta; // positive for heal, negative for damage

    public HealthEventArgs(float current, float max, float delta)
    {
        this.current = current;
        this.max = max;
        this.delta = delta;
    }
}
namespace GreenOneFoodTrucks.Domain
{
    public class FieldFilter<T>
    {
        public string Name { get; private set; }
        public T Value { get; private set; }
        public FieldFilter(string name, T value)
        {
            Name = name;
            Value = value;
        }
    }
}

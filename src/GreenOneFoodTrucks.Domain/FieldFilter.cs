namespace GreenOneFoodTrucks.Domain
{
    public class FieldFilter
    {
        public string Name { get; private set; }
        public string Value { get; private set; }
        public FieldFilter(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}

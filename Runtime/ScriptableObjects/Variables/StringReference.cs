namespace BirdTools
{
    public class StringReference : VariableReference
    {
        public string ConstantValue;
        public StringVariable Variable;

        public StringReference()
        { }

        public StringReference(string value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        public string Value
        {
            get { return UseConstant ? ConstantValue : Variable.Value; }
        }

        public static implicit operator string(StringReference reference)
        {
            return reference.Value;
        }
    }
}
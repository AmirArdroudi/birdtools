using System;

namespace BirdTools
{
    [Serializable]
    public class IntReference : VariableReference
    {
        public int ConstantValue;
        public IntVariable Variable;

        public IntReference()
        { }

        public IntReference(int value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        public int Value
        {
            get { return UseConstant ? ConstantValue : Variable.Value; }
        }

        public static implicit operator int(IntReference reference)
        {
            return reference.Value;
        }
    }
}
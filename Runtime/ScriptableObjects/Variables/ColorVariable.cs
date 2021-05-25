using UnityEngine;

namespace BirdTools
{
    [CreateAssetMenu(fileName = "varColor_", menuName = "BirdTools/Variables/Color", order = 0)]
    public class ColorVariable : ScriptableObject
    {
        public Color Value;
        public void SetValue(Color value)
        {
            Value = value;
        }

        public void SetValue(ColorVariable value)
        {
            Value = value.Value;
        }
        
        public void ApplyChange(Color amount)
        {
            Value += amount;
        }

        public void ApplyChange(ColorVariable amount)
        {
            Value += amount.Value;
        }
    }
}
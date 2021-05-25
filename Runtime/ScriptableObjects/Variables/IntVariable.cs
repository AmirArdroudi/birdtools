using UnityEngine;

namespace BirdTools
{
    [CreateAssetMenu(fileName = "varF_", menuName = "BirdTools/Variables/Int")]
    public class IntVariable : ScriptableObject
    {
        public int Value;
        public void SetValue(int value)
        {
            Value = value;
        }

        public void SetValue(IntVariable value)
        {
            Value = value.Value;
        }
        
        public void ApplyChange(int amount)
        {
            Value += amount;
        }

        public void ApplyChange(IntVariable amount)
        {
            Value += amount.Value;
        }
    }
}
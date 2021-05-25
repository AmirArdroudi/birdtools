using UnityEngine;

namespace BirdTools
{
    [CreateAssetMenu (fileName = "varS_", menuName = "BirdTools/Variables/String")]
    public class StringVariable : ScriptableObject
    {
        public string Value;

        public void SetValue(string value)
        {
            Value = value;
        }
        public void SetValue(StringVariable value)
        {
            Value = value.Value;
        }
        
        

    }
}
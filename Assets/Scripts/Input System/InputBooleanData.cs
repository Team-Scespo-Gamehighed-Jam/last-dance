using UnityEngine;

namespace Input_System
{
    [CreateAssetMenu(fileName = "InputBooleanData_", menuName = "Game/Input Boolean Data", order = 0)]
    public class InputBooleanData : ScriptableObject
    {
        [SerializeField] private KeyCode key;
        [SerializeField] private bool value;

        public bool Value
        {
            get => value;
            set => this.value = value;
        }

        public void Process()
        {
            value = Input.GetKey(key);
        }
        
    }
}
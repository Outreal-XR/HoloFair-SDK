using UnityEngine;

namespace outrealxr.holomod
{
    public class WaitForSecondsNode : WaitNode
    {
        [Input, SerializeField] private float _seconds;
        
        protected override YieldInstruction GetAwaitPeriod() {
            if (GetInputPort("_seconds").IsConnected) 
                _seconds = GetInputValue<float>("_seconds");
            return new WaitForSeconds(_seconds);
        }
    }
}

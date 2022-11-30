using System;
using UnityEngine;
using XNode;

namespace outrealxr.holomod
{
    [CreateNodeMenu("Logic/Logic Gate")]
    public class LogicGateNode : SequenceNode
    {
        [Input, SerializeField] private bool _a; 
        [Input, SerializeField] private bool _b;
        
        [Output, SerializeField] private bool _result;

        [SerializeField] private Logic Logic;

        public override object GetValue(NodePort port) {
            var aPort = GetInputPort("_a");
            var bPort = GetInputPort("_b");
            if (aPort.IsConnected) aPort.TryGetInputValue(out _a);
            if (bPort.IsConnected) bPort.TryGetInputValue(out _b);
            
            if (port.fieldName.Equals("_result")) return Logic switch {
                Logic.And => _a && _b,
                Logic.Or => _a || _b,
                Logic.Xor => _a ^ _b,
                _ => throw new ArgumentOutOfRangeException()
            };
            return base.GetValue(port);
        }

        protected override void ExecuteLogic() {
        }
    }
    
    public enum Logic { 
        And,
        Or,
        Xor
    }
}

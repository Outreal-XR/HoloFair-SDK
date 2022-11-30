using System;
using UnityEngine;
using XNode;

namespace outrealxr.holomod
{
    [CreateNodeMenu("Math/Operations")]
    public class MathOperationNode : SequenceNode
    {
        [Input, SerializeField] private float _a;
        [Input, SerializeField] private float _b;
        [Output, SerializeField] private float _output;
        [SerializeField] private OperationType _operationType;
        
        protected override void ExecuteLogic() { }

        public override object GetValue(NodePort port) {
            var aPort = GetInputPort("_a");
            var bPort = GetInputPort("_b");
            if (aPort.IsConnected) aPort.TryGetInputValue(out _a);
            if (bPort.IsConnected) bPort.TryGetInputValue(out _b);
            
            if (port.fieldName.Equals("_output")) return _operationType switch {
                OperationType.Addition => _a + _b,
                OperationType.Subtraction => _a - _b,
                OperationType.Multiplication => _a * _b,
                OperationType.Division => _a / _b,
                OperationType.Power => Mathf.Pow(_a, _b),
                OperationType.Modulo => _a % _b,
                _ => throw new ArgumentOutOfRangeException()
            };
            
            return base.GetValue(port);
        }
    }
}
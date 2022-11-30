using System;
using UnityEngine;
using XNode;

namespace outrealxr.holomod
{
    public class FloatComparisonNode : SequenceNode
    {
        [Input, SerializeField] private float _a;
        [Input, SerializeField] private float _b;

        [Output, SerializeField] private bool _output;

        [SerializeField] private ComparisonType _comparisonType;
        
        protected override void ExecuteLogic() { }

        public override object GetValue(NodePort port) {
            if (GetInputPort("_a").IsConnected)
                _a = GetInputValue<float>("_a");
            if (GetInputPort("_b").IsConnected)
                _b = GetInputValue<float>("_b");
            
            if (port.fieldName.Equals("_output")) {
                return _comparisonType switch {
                    ComparisonType.GreaterThan => _a > _b,
                    ComparisonType.LessThan => _a < _b,
                    ComparisonType.EqualTo => Math.Abs(_a - _b) < 0.01f,
                    ComparisonType.GreaterThanOrEqual => _a >= _b,
                    ComparisonType.LessThanOrEqual => _a <= _b,
                    ComparisonType.NotEqual => Math.Abs(_a - _b) > 0.01f,
                    _ => throw new ArgumentOutOfRangeException()
                };
            }
            
            
            return base.GetValue(port);
        }
    }

    public enum ComparisonType
    {
        GreaterThan,
        LessThan,
        EqualTo,
        GreaterThanOrEqual,
        LessThanOrEqual,
        NotEqual
    }
}
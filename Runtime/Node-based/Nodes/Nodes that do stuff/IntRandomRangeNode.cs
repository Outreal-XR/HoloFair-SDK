using UnityEngine;
using XNode;

namespace outrealxr.holomod
{
    public class IntRandomRangeNode : SequenceNode
    {
        [Input, SerializeField] private int _minInclusive;
        [Input, SerializeField] private int _maxExclusive;

        [Output, SerializeField] private int _output;

        public override object GetValue(NodePort port) {
            if (port.fieldName.Equals("_output")) return _output;
            return base.GetValue(port);
        }

        protected override void ExecuteLogic() {
            if (GetInputPort("_minInclusive").IsConnected) 
                _minInclusive = GetInputValue<int>("_minInclusive");
            if (GetInputPort("_maxExclusive").IsConnected) 
                _maxExclusive = GetInputValue<int>("_maxExclusive");

            _output = Random.Range(_minInclusive, _maxExclusive);
        }
    }
}
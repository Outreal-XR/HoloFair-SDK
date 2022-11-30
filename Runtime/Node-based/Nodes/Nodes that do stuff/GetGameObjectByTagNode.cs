using UnityEngine;
using XNode;

namespace outrealxr.holomod
{
    public class GetGameObjectByTagNode : SequenceNode
    {
        [Input, SerializeField] private string _tag;
        [Output, SerializeField] private GameObject _output;

        protected override void ExecuteLogic() {
            if (GetInputPort("_tag").IsConnected)
                _tag = GetInputValue<string>("_tag");
            
            _output = GameObject.FindWithTag(_tag);
        }

        public override object GetValue(NodePort port) {
            if (port.fieldName.Equals("_output")) return _output;
            return base.GetValue(port);
        }
    }
}
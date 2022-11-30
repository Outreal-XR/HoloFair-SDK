using UnityEngine;
using XNode;

namespace outrealxr.holomod
{
    [CreateNodeMenu("Physics/Get Velocity")]
    public class GetVelocityNode : SequenceNode
    {
        [Input, SerializeField] private Rigidbody _rigidbody;
        [Output, SerializeField] private Vector3 _velocity;
        
        protected override void ExecuteLogic() {
            if (GetInputPort("_rigidbody").IsConnected) 
                _rigidbody = GetInputValue<Rigidbody>("_rigidbody") ?? GetInputValue<Component>("_rigidbody") as Rigidbody;
            

            _velocity = _rigidbody.velocity;
        }
        
        public override object GetValue(NodePort port) {
            if (port.fieldName.Equals("_velocity")) return _velocity;
            return base.GetValue(port);
        }
    }
}
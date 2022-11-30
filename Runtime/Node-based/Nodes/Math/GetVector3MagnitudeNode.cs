using UnityEngine;
using XNode;

namespace outrealxr.holomod
{
    [CreateNodeMenu("Math/Get Vector Magnitude")]
    public class GetVector3MagnitudeNode : SequenceNode
    {
        [Input, SerializeField] private Vector3 _vector3;
        [Output, SerializeField] private float _magnitude;
        
        protected override void ExecuteLogic() { }

        public override object GetValue(NodePort port) {
            if (port.fieldName.Equals("_magnitude")) {
                if (GetInputPort("_vector3").IsConnected) 
                    _vector3 = GetInputValue<Vector3>("_vector3");
                return _vector3.magnitude;
            }
            
            return base.GetValue(port);
        }
    }
}
using System;
using UnityEngine;
using XNode;

namespace outrealxr.holomod
{
    public class GetComponentNode : SequenceNode
    {
        [Input, SerializeField] private GameObject _gameObject;
        [Output, SerializeField] private Component _component;

        [SerializeField] private ComponentType _type;

        protected override void ExecuteLogic() {
            if (GetInputPort("_gameObject").IsConnected)
                _gameObject = GetInputValue<GameObject>("_gameObject");

            _component = _gameObject.GetComponent(GetType(_type));
        }

        private static Type GetType(ComponentType type) {
            return type switch {
                ComponentType.Transform => typeof(Transform),
                ComponentType.Rigidbody => typeof(Rigidbody),
                ComponentType.Collider => typeof(Collider),
                ComponentType.BoxCollider => typeof(BoxCollider),
                ComponentType.SphereCollider => typeof(SphereCollider),
                ComponentType.MeshCollider => typeof(MeshCollider),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
        
        public override object GetValue(NodePort port) {
            if (port.fieldName.Equals("_component")) return _component;
            return base.GetValue(port);
        }
    }

    public enum ComponentType
    {
        Transform,
        Rigidbody,
        Collider,
        BoxCollider,
        SphereCollider,
        MeshCollider
    }
}
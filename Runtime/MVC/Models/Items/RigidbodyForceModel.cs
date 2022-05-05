using UnityEngine;

namespace outrealxr.holomod {
    public class RigidbodyForceModel : Model
    {
        [SerializeField] private Vector3 force;
        [SerializeField] private ForceMode forceMode;
        [SerializeField] private bool useFixedDeltaTime;

        public Vector3 Force => force;
        public ForceMode ForceMode => forceMode;
        public bool UseFixedDeltaTime => useFixedDeltaTime;
        
        public override string type => "RigidbodyForce";
    }
}
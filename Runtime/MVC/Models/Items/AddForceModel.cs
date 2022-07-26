using UnityEngine;

namespace outrealxr.holomod
{
    public class AddForceModel : Model
    {
        public override string type => "force";

        public Vector3 force;
        public ForceMode forceMode;
        
        [HideInInspector] public Rigidbody playerRb;
    }
}
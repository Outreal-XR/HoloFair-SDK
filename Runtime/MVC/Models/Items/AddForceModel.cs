using UnityEngine;

namespace outrealxr.holomod
{
    public class AddForceModel : Model
    {
        public override string type => "force";

        public float force = 1;
        public ForceMode forceMode;
        
        [HideInInspector] public Rigidbody playerRb;
    }
}
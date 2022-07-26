using Newtonsoft.Json.Linq;
using UnityEngine;

namespace outrealxr.holomod
{
    public class ControlsLockModel : Model
    {
        public GameObject target;

        private void Awake()
        {
            if (target == null) target = gameObject;
        }

        public override string type => "controlsLock";
    }
}
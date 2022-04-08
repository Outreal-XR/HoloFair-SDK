using Newtonsoft.Json.Linq;
using UnityEngine;

namespace outrealxr.holomod
{
    public class ControlsLockProvider : Provider
    {
        public GameObject target;

        private void Awake()
        {
            if (target == null) target = gameObject;
        }

        public override string ModKey => "controlsLock";

        public override string providerType => GetType().Name;

        public override void FromJObject(JObject data) { }

        public override bool IsDirty()
        {
            return isDirty;
        }

        public override void SetIsDirty(bool val)
        {
            isDirty = val;
        }

        public override JObject ToJObject()
        {
            return new JObject();
        }
    }
}
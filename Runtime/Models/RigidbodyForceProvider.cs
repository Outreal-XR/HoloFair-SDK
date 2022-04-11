using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace outrealxr.holomod {
    public class RigidbodyForceProvider : Provider
    {
        [SerializeField] private Vector3 force;
        [SerializeField] private ForceMode forceMode;
        [SerializeField] private bool useFixedDeltaTime;

        public Vector3 Force => force;
        public ForceMode ForceMode => forceMode;
        public bool UseFixedDeltaTime => useFixedDeltaTime;
        
        public override string ModKey => "RigidbodyForce";
        public override string providerType => GetType().Name;

        public override void SetIsDirty(bool val) => isDirty = val;

        public override bool IsDirty() => isDirty;

        public override JObject ToJObject() => new JObject();

        public override void FromJObject(JObject data) { }
    }
}
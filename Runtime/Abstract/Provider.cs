using BehaviorDesigner.Runtime;
using Newtonsoft.Json.Linq;
using System;
using UnityEngine;

namespace outrealxr.holomod
{
    public abstract class Provider : MonoBehaviour
    {
        public bool isDirty = true;

        public abstract string ModKey { get; }

        public abstract void SetIsDirty(bool val);

        public abstract bool IsDirty();

        public abstract JObject ToJObject();

        public abstract void FromJObject(JObject data);

        public abstract string providerType { get; }
    }
}
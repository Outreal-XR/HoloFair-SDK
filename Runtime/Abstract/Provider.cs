//using BehaviorDesigner.Runtime;
using Newtonsoft.Json.Linq;
using System;
using UnityEngine;

namespace outrealxr.holomod
{
    [RequireComponent(typeof(Model), typeof(View))]
    public abstract class Provider : MonoBehaviour
    {
        [Tooltip("If true then it will make this provider distributed over network. When false, it allows server use data that comes from Web Portal, otherwise it will override any data from portal by values used in the provider. Usually, it should be true for AnimatorProvider and PlayableDirectorProvider.")]
        public bool isDirty = false;

        public abstract string ModKey { get; }

        public virtual void SetIsDirty(bool val) => isDirty = val;

        public virtual bool IsDirty() => isDirty;

        public abstract JObject ToJObject();

        public abstract void FromJObject(JObject data);

        public abstract string providerType { get; }
        
        private void Reset() {
            gameObject.GetComponent<Model>().provider = this;
        }
    }
}
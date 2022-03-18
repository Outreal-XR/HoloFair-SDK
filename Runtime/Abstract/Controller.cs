using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace outrealxr.holomod
{
    public abstract class Controller : MonoBehaviour
    {
        public Model model;

        protected void Awake()
        {
            model = GetComponentInParent<Model>();
        }

        public abstract void Handle();

        public abstract void Sync();

        public abstract void Read();

        public abstract void ReadForAll();

        public virtual void LockPlayerControls()
        {
            Debug.LogWarning($"[SDKModelController] {gameObject.name} does't have any implemention of {nameof(LockPlayerControls)}");
        }

        public virtual void UnlockPlayerControls()
        {
            Debug.LogWarning($"[SDKModelController] {gameObject.name} does't have any implemention of {nameof(UnlockPlayerControls)}");
        }
    }
}
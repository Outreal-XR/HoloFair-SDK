using UnityEngine;

namespace outrealxr.holomod
{
    public abstract class Controller : MonoBehaviour
    {
        public Model model;

        public virtual void SetModel(Model model)
        {
            this.model = model;
        }

        public abstract void Handle();

        public abstract void Write();

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
using UnityEngine;

namespace outrealxr.holomod
{
    public abstract class Controller : MonoBehaviour
    {
        public Model model;

        private void Start()
        {
            WorldController.instance.controllers.Add(this);
        }

        public virtual void SetModel(Model model)
        {
            this.model = model;
        }

        public abstract void Handle();

        public virtual void Read()
        {
            model.FromJObject(WorldModel.instance.ReadData(model.guid));
        }

        public virtual void Write()
        {
            WorldModel.instance.WriteData(model.MMOItemID, model.guid, model.ToJObject());
        }

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
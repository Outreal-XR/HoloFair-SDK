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
            try
            {
                if (model != null) model.FromJObject(WorldModel.instance.ReadData(model.guid));
                else Debug.Log($"[ModelController] Unable to read the model because it is null.");
            }
            catch (System.Exception ex)
            {
                if (model == null) Debug.Log($"[ModelController] Unable to read the model because it is null.");
                else Debug.Log($"[ModelController] Error was detected on read at {model.gameObject.name}: <color=#ed1a1a>{ex}</color>");
            }
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
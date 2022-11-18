using UnityEngine;

namespace outrealxr.holomod
{
    public abstract class View : MonoBehaviour
    {

        public enum EditAccess
        {
            None,
            Private,
            Public
        }

        public Model model;
        [Tooltip("Generic controller which later used by inherited classes on start")]
        public Controller controller;
        GameObject loadedAddressable;
        public EditAccess editAccess = EditAccess.Private;
        public bool ReadOnStart = true;

        void Awake()
        {
            if (WorldController.instance) controller = WorldController.instance.GetController(model);
            else Debug.LogWarning($"[View] WorldController instance doesn't exist. {gameObject.name} has no handle, write and read logic available.");
        }

        public virtual void Init() { }

        public abstract void Apply();

        public void Handle()
        {
            if (!CheckForController()) return;
            
            controller.SetModel(model);
            controller.Handle();
        }

        public abstract void Edit();

        public void Write()
        {
            if (!CheckForController()) return;

            controller.SetModel(model);
            controller.Write();
        }

        public void Read()
        {
            if (!CheckForController()) return;
             
            controller.SetModel(model);
            controller.Read();
        }

        protected bool CheckForController() {
            if (!controller)
                Debug.LogWarning($"[View] Controller wasn't assigned. {gameObject.name} has no handle, write and read logic available.");

            return controller != null;
        }

        public void LoadAddressable(string path)
        {
            if (loadedAddressable) Destroy(loadedAddressable);
        }
    }
}
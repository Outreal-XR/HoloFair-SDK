using UnityEngine;

namespace outrealxr.holomod
{
    public abstract class View : MonoBehaviour
    {
        public Model model;
        [Tooltip("Generic controller which later used by inherited classes on start")]
        public Controller controller;
        GameObject loadedAddressable;

        void Awake()
        {
            if(WorldController.instance) controller = WorldController.instance.GetController(model);
            else Debug.LogWarning($"[View] WorldController instance doesn't exist. {gameObject.name} has no handle, write and read logic available.");
        }

        public abstract void Apply();

        public void Handle()
        {
            controller.SetModel(model);
            controller.Handle();
        }

        public abstract void Edit();

        public void Write()
        {
            controller.SetModel(model);
            controller.Write();
        }

        public void Read()
        {
            controller.SetModel(model);
            controller.Read();
        }

        public void LoadAddressable(string path)
        {
            if (loadedAddressable) Destroy(loadedAddressable);
        }
    }
}
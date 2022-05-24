using UnityEngine;

namespace outrealxr.holomod
{
    public abstract class View : MonoBehaviour
    {
        public Model model;
        public Controller controller;
        GameObject loadedAddressable;

        void Awake()
        {
            controller = WorldController.instance.GetController(model);
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
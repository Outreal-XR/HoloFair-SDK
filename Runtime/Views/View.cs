using UnityEngine;

namespace outrealxr.holomod
{
    public class View : MonoBehaviour
    {
        public Controller controller;
        GameObject loadedAddressable;
        public SendMessageOptions sendMessageOptions = SendMessageOptions.DontRequireReceiver;

        public void Handle()
        {
            controller.Handle();
        }

        public void SetController(Controller controller)
        {
            this.controller = controller;
        }

        public void Sync()
        {
            controller.Sync();
        }

        public void Read()
        {
            controller.Read();
        }

        public void ReadForAll()
        {
            controller.ReadForAll();
        }

        public void SendMessageToController(string msg)
        {
            controller.SendMessage(msg, sendMessageOptions);
        }

        public void LoadAddressable(string path)
        {
            if (loadedAddressable) Destroy(loadedAddressable);
        }
    }
}
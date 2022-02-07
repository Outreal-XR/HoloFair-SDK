using UnityEngine;

namespace outrealxr.holomod
{
    public class View : MonoBehaviour
    {
        public Controller controller;
        public SendMessageOptions sendMessageOptions = SendMessageOptions.DontRequireReceiver;

        public void Handle()
        {
            controller.Handle();
        }

        public void SetController(Controller controller)
        {
            this.controller = controller;
        }

        public void SendMessageToController(string msg)
        {
            controller.SendMessage(msg, sendMessageOptions);
        }
    }
}
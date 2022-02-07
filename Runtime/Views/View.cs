using UnityEngine;

namespace outrealxr.holomod
{
    public class View : MonoBehaviour
    {
        public Controller controller;
        public SendMessageOptions sendMessageOptions = SendMessageOptions.DontRequireReceiver;

        public void SetController(Controller controller)
        {
            this.controller = controller;
        }

        public void SendMessageToController(string msg, bool arg)
        {
            controller.SendMessage(msg, arg, sendMessageOptions);
        }

        public void SendMessageToController(string msg, string arg)
        {
            controller.SendMessage(msg, arg, sendMessageOptions);
        }

        public void SendMessageToController(string msg, float arg)
        {
            controller.SendMessage(msg, arg, sendMessageOptions);
        }

        public void SendMessageToController(string msg, int arg)
        {
            controller.SendMessage(msg, arg, sendMessageOptions);
        }
    }
}
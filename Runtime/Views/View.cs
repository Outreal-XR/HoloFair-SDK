using UnityEngine;

namespace outrealxr.holomod
{
    public class View : MonoBehaviour
    {
        public Controller controller;

        public void SetController(Controller controller)
        {
            this.controller = controller;
        }
    }
}
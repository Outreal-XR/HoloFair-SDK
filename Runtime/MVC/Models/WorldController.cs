using UnityEngine;

namespace outrealxr.holomod
{
    public class WorldController : MonoBehaviour
    {

        public Controller[] controllers;
        public static WorldController instance;

        private void Awake()
        {
            instance = this;
        }

        public Controller GetController(Model model)
        {
            foreach (var controller in controllers)
                if (controller.gameObject.name == model.type)
                    return controller;
            return null;
        }
    }
}
using System.Collections.Generic;
using UnityEngine;

namespace outrealxr.holomod
{
    public class WorldController : MonoBehaviour
    {

        public List<Controller> controllers;
        public static WorldController instance;

        private void Awake()
        {
            instance = this;
            controllers.Clear();
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
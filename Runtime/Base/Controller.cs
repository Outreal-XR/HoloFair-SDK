using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace outrealxr.holomod
{
    public class Controller : MonoBehaviour
    {
        public Model model;

        protected void Awake()
        {
            model = GetComponentInChildren<Model>();
        }

        public void Handle()
        {

        }
    }
}
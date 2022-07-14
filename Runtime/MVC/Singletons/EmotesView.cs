using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace outrealxr.holomod.Runtime
{
    public class EmotesView : MonoBehaviour
    {

        public GameObject view;
        public static EmotesView instance;

        void Awake()
        {
            instance = this;
        }

        public void Open()
        {
            view.SetActive(true);
        }
    }
}
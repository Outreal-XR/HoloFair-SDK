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
            if (instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        public void Open()
        {
            view.SetActive(true);
        }
    }
}
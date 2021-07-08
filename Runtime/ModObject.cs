using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



namespace OutrealXR.HoloMod.Runtime
{
    [SerializeField]
    public class ModObject : MonoBehaviour
    {
        [HideInInspector]
        [SerializeField]
        public int type = -1;
        [HideInInspector]
        [SerializeField]
        public ModVar[] modVars = new ModVar[] { };
        public bool syncronized = false;
        public bool executeOnInit = false;
        public bool executeOnRecieve = false;
        public UnityEvent BeforeExecute;
        public UnityEvent AfterExecute;

        void Awake()
        {
            ModRegistry.Instance.RegisterModObject(this);
        }
    }
}
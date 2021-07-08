using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



namespace OutrealXR.HoloMod.Runtime
{
    [SerializeField]
    public class ModObject : MonoBehaviour
    {
        public enum mouseCursors
        {
            Default,
            Info,
            Link,
            Video,
            Interactable,
            Seat
        }
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
        public mouseCursors OnHoverMouseCursor;

        // Start is called before the first frame update
        void Awake()
        {
            ModRegistry.Instance.RegisterModObject(this);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
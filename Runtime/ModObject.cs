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
        [HideInInspector]
        public UnityEvent OnAction;

        void Awake()
        {
            ModRegistry.Instance.RegisterModObject(this);
        }

        public bool SetModVarVal(string modVarName, string val)
        {
            int index = GetModVarIndexByName(modVarName);
            if (index >= 0) modVars[index].value = val;
            return index >= 0;
        }

        public int GetModVarIndexByName(string modVarName)
        {
            for (int i = 0; i < modVars.Length; i++)
                if (modVars[i].varName == modVarName)
                    return i;
            return -1;
        }

        public ModVar GetModVarByName(string modVarName)
        {
            int index = GetModVarIndexByName(modVarName);
            if (index >= 0) return modVars[index];
            return null;
        }
    }
}
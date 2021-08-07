using UnityEngine;
using UnityEngine.Events;

namespace OutrealXR.HoloMod.Runtime
{
    [System.Serializable]
    public class ModVar
    {
        public ModVar(ModVar other)
        {
            varName = other.varName;
            value = other.value;
            varType = other.varType;
        }

        public enum Type //Variable Types 
        {
            Bool,//if True then true
            Int,
            Float,
            String,
            List,//must be valid json array [1, 2, 3, ...], [1.1, 2.2, 3.3, ...] etc
            UnityEvent
        }

        //Variable properties
        [SerializeField]
        public string varName = "";
        [SerializeField][HideInInspector]
        public string value = "";
        [SerializeField]
        public Type varType = 0;
        public UnityEvent OnAction;

        public void Act()
        {
            OnAction.Invoke();
        }
    }
}
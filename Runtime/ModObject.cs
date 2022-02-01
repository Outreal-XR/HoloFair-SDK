using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace OutrealXR.HoloMod.Runtime
{
    [SerializeField]
    [ExecuteInEditMode]
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
        [Tooltip("Should be selected based on dropdown menu")]
        public int type = -1;
        [HideInInspector]
        [SerializeField]
        [Tooltip("Only of the variables can be updated")]
        public ModVar[] modVars = new ModVar[] { };
        [Tooltip("Execute modifer when it is initialized")]
        public bool executeOnInit = false;
        [Tooltip("Execute modifer when it is updated")]
        public bool executeOnRecieve = false;
        [Tooltip("Syncronize Object's Transform across the network")]
        public bool syncTransformation = false;
        [Tooltip("This object will only be used locally (Multiplayer)")]
        public bool isLocal = false;
        [Tooltip("Fires this event before modifier is executed")]
        public UnityEvent BeforeExecute;
        [Tooltip("Fires this event after modifier is executed")]
        public UnityEvent AfterExecute;
        public mouseCursors OnHoverMouseCursor;
        ModRegistry modRegistry;

        void Start() {
            //TODO dirty fix, if better approach not found then it will cause a few seconds extra freeze on venue load
            StartCoroutine(Init());
        }

        IEnumerator Init() {
            var scene = gameObject.scene;
            
            //Super smart fix. 
            yield return new WaitUntil(() => FindObjectOfType<ModRegistry>().gameObject.scene.Equals(scene));
            modRegistry = FindObjectOfType<ModRegistry>();
            
            if (modRegistry != null) modRegistry.RegisterModObject(this);
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
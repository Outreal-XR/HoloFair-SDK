using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace OutrealXR.HoloMod.Runtime
{
    public class ModRegistry : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Must be asset of variables, based on which ModObjects variables can be prepared")]
        public ModObjectDataAsset modObjectDataAsset = null;
        List<ModObject> ModObjects = new List<ModObject>(); // List of all Mods in the scene
        [Tooltip("It used by ModObjects to decide wether they should init themselves or not on awake")]
        public bool InitOnStart = true;

        public static ModRegistry Instance;

        private void Awake()
        {
            Instance = this;
        }

        public void ClearModObjects()
        {
            ModObjects.Clear();
        }

        /// <summary>
        /// Register new modObject. Used by ModObject and can be used externally to cusomize initilization
        /// </summary>
        /// <param name="newModObj">ModObjec that needs to be registered</param>
        /// <returns></returns>
        public int RegisterModObject(ModObject newModObj)
        {
            if (ModObjects.Contains(newModObj))
            {
                Debug.LogWarning(string.Format("[ModRegistry] Mod ({0}) in Object {1} already exists in the Mods list!", newModObj.type, newModObj.gameObject.name));
                return 1;//AlreadyExists
            }
            else
            {
                ModObjects.Add(newModObj);
                Debug.Log($"[ModRegistry] added {newModObj.name}");
                return 0;//NoError
            }
        }

        public void UnregisterModObject(ModObject modObject)
        {
            if(ModObjects.Contains(modObject))
                ModObjects.Remove(modObject);
        }

        public List<ModObject> GetModObjects()
        {
            return ModObjects;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace OutrealXR.HoloMod.Runtime
{
    public class ModRegistry : MonoBehaviour
    {
        [SerializeField]
        public ModObjectDataAsset modObjectDataAsset = null;
        List<ModObject> ModObjects = new List<ModObject>(); // List of all Mods in the scene

        //Register new modObject
        public int RegisterModObject(ModObject newModObj)
        {
            if (ModObjects.Contains(newModObj))
            {
                Debug.LogError(string.Format("[ModRegistry] Mod ({0}) in Object {1} already exists in the Mods list!", newModObj.type, newModObj.gameObject.name));
                return 1;//AlreadyExists
            }
            else
            {
                ModObjects.Add(newModObj);
                Debug.Log($"[ModRegistry] added {newModObj.name}");
                return 0;//NoError
            }

        }

        public List<ModObject> GetModObjects()
        {
            return ModObjects;
        }

        //Singleton Mod//
        public static ModRegistry manager;

        public static ModRegistry Instance
        {
            get
            {
                if (manager == null)
                    manager = FindObjectOfType<ModRegistry>();
                return manager;
            }
            set
            {
                manager = value;
            }
        }

    }




}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace OutrealXR.HoloMod.Runtime
{
    [CreateAssetMenu(fileName = "New ModObjectData", menuName = "HolofairMods/ModObjectData", order = 1)]
    public class ModObjectData : ScriptableObject
    {
        public string mName;
        [SerializeField]
        public ModVar[] modVars;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace OutrealXR.HoloMod.Runtime
{
    [CreateAssetMenu(fileName = "New ModObjectDataAsset", menuName = "HolofairMods/ModObjectDataAsset", order = 1)]
    public class ModObjectDataAsset : ScriptableObject
    {
        public ModObjectData[] SupportedModifiers;
    }
}   
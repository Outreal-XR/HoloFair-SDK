using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Bool, Int, Float, String, List /*Use json syntax*/, UnityEvent//TODO: implement those
        }

        //Variable properties
        [SerializeField]
        public string varName = "";
        [SerializeField][HideInInspector]
        public string value = "";
        [SerializeField]
        public Type varType = 0;
    }
}
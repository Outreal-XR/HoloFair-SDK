using System;
using UnityEditor;
using UnityEngine;

namespace outrealxr.holomod.Editor
{
    [CustomEditor(typeof(RespawnProvider))]
    public class RespawnProviderEditor : UnityEditor.Editor
    {
        private void Reset() {
            EditorApplication.projectChanged += UpdateSceneString;
        }

        private void OnDestroy() {
            EditorApplication.projectChanged -= UpdateSceneString;
        }

        private void OnValidate() {
            UpdateSceneString();
        }
        
        private void UpdateSceneString() {
            var mod = (RespawnProvider) target;

            Debug.Log(mod.scene.Asset.name);
            mod.gameObject.name = mod.scene.Asset.name;
        }
    }
}
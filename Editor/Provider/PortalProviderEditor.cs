using System;
using UnityEditor;
using UnityEngine;

namespace outrealxr.holomod.Editor
{
    [CustomEditor(typeof(PortalProvider))]
    public class PortalProviderEditor : UnityEditor.Editor
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
            var mod = (PortalProvider) target;
            
            Debug.Log(mod.scene.Asset.name);
            mod.sceneName = mod.scene.Asset.name;
        }
    }
}
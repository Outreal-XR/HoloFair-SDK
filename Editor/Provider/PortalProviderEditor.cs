using System;
using UnityEditor;

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

        private void UpdateSceneString() {
            var mod = (PortalProvider) target;

            mod.sceneName = mod.scene.Asset.name;
        }
    }
}
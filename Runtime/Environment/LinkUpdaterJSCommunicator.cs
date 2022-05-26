using System.Runtime.InteropServices;
using UnityEngine;

namespace outrealxr.holomod
{
    public class LinkUpdaterJSCommunicator : MonoBehaviour
    {
        [DllImport("__Internal")]
        private static extern void openDrawer();
        
        public void OpenInputFieldOnBrowser () {
#if UNITY_EDITOR
            Debug.LogWarning("[LinkUpdaterJSCommunicator] Attempted to open JS UI inside editor.");
#elif UNITY_WEBGL
            openDrawer();
#else
            Debug.LogWarning("[LinkUpdaterJSCommunicator] Attempted to open JS UI inside non WebGL platform.");
#endif
        }

        public void UpdateLink(string newLink) {
            EditLinkView.instance.OnLinkUrlChange(newLink);
            EditLinkView.instance.Apply();
        }

        private void Awake() {
            instance = this;
        }

        public static LinkUpdaterJSCommunicator instance;
    }
}
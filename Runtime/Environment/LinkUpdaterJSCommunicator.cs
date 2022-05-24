using System.Runtime.InteropServices;
using UnityEngine;

namespace outrealxr.holomod
{
    public class LinkUpdaterJSCommunicator : MonoBehaviour
    {
        [DllImport("__Internal")]
        private static extern void OpenInputField();
        
        public void OpenInputFieldOnBrowser () {
#if UNITY_WEBGL
            OpenInputField();
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
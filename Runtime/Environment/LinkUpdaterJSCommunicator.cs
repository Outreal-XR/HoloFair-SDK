using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace outrealxr.holomod
{
    public class LinkUpdaterJSCommunicator : MonoBehaviour
    {
        private BasicLinkView _linkView;        
        
        [DllImport("__Internal")]
        private static extern void OpenInputField();
        
        public void OpenInputFieldOnBrowser (BasicLinkView linkView) {
#if UNITY_WEBGL
            _linkView = linkView;
            OpenInputField();
#endif
        }

        public void UpdateLink(string newLink) {
            _linkView.ReceiveLinkUpdate(newLink);
        }

        private void Awake() {
            if (_instance == null) {
                _instance = this;
            } else if (!_instance.Equals(this)) {
                Destroy(this);
            }
        }

        private static LinkUpdaterJSCommunicator _instance;
        public static LinkUpdaterJSCommunicator Instance {
            get {
                if (_instance != null) return _instance;

                _instance = FindObjectOfType<LinkUpdaterJSCommunicator>();
                if (_instance != null) return _instance;

                Debug.LogError("Could not find <b>singleton</b> instance of <b>[LinkUpdaterJSCommunicator]</b>");
                return null;
            }
        }
    }
}
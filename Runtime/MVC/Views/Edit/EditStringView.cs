using UnityEngine;

namespace outrealxr.holomod
{
    public class EditStringView : MonoBehaviour
    {
        public static EditStringView instance;

        public GameObject form;
        public TMPro.TMP_InputField urlInput;
        BasicStringView basicStringView;

        private void Awake()
        {
            instance = this;
        }

        public void SetLinkView(BasicStringView basicStringView)
        {
            this.basicStringView = basicStringView;
            form.SetActive(basicStringView);
        }

        public void OnLinkUrlChange(string val)
        {
            urlInput.text = val;
        }

        public void Apply()
        {
            if(basicStringView)
            {
                basicStringView.ReceiveLinkUpdate(urlInput.text);
                basicStringView.Write();
            }
            else
            {
                Debug.LogWarning("[EditLinkView] Attempted to apply a value, but basicLinkView wasn't set.");
            }
        }

        public void StartEdit(BasicStringView basicStringView)
        {
            SetLinkView(basicStringView);
        }

        public void StartEdit()
        {
            if (basicStringView)
            {
                StartEdit(basicStringView);
                LinkUpdaterJSCommunicator.instance.OpenInputFieldOnBrowser();
            }
        }

        public void EndEdit()
        {
            SetLinkView(null);
        }
    }
}
using UnityEngine;

namespace outrealxr.holomod
{
    public class EditLinkView : MonoBehaviour
    {
        public static EditLinkView instance;

        public GameObject form;
        public TMPro.TMP_InputField urlInput;
        BasicLinkView basicLinkView;

        private void Awake()
        {
            instance = this;
        }

        public void SetLinkView(BasicLinkView basicLinkView)
        {
            this.basicLinkView = basicLinkView;
            form.SetActive(basicLinkView);

        }

        public void OnLinkUrlChange(string val)
        {
            urlInput.text = val;
        }

        public void Apply()
        {
            if(basicLinkView)
            {
                basicLinkView.ReceiveLinkUpdate(urlInput.text);
                basicLinkView.Write();
            }
        }

        public void StartEdit(BasicLinkView basicLinkView)
        {
            SetLinkView(basicLinkView);
        }

        public void StartEdit()
        {
            if (basicLinkView)
            {
                StartEdit(basicLinkView);
                LinkUpdaterJSCommunicator.instance.OpenInputFieldOnBrowser();
            }
        }

        public void EndEdit()
        {
            SetLinkView(null);
        }
    }
}
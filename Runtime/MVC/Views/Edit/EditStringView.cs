using UnityEngine;

namespace outrealxr.holomod
{
    public class EditStringView : MonoBehaviour
    {
        public static EditStringView instance;

        public GameObject form;
        public TMPro.TMP_InputField urlInput;
        protected BasicStringView basicStringView;

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
            if(!basicStringView)
            {
                Debug.LogWarning("[EditLinkView] Attempted to apply a value, but there is nothing to edit");
                return;
            }
            if(!urlInput)
            {
                Debug.LogWarning("[EditLinkView] Attempted to apply a value, but input field is missing.");
                return;
            }
            basicStringView.ReceiveLinkUpdate(urlInput.text);
            basicStringView.Write();
            EndEdit();
        }

        public virtual void StartEdit(BasicStringView basicStringView)
        {
            SetLinkView(basicStringView);
            OnLinkUrlChange((basicStringView.model as StringModel).value);
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
            LinkUpdaterJSCommunicator.instance.ResumeWebGLFocus();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace outrealxr.holomod
{
    public class BasicTextFeedbackController : BasicStringController
    {

        string endpoint;

        [Header("UI")]
        public GameObject View;
        public CanvasGroup canvasGroup;
        public TMPro.TextMeshProUGUI Title;
        public TMPro.TMP_InputField InputField;
        public UnityEngine.UI.Button SubmitButton;

        public override void Handle()
        {
            string[] data = (model as TextFeedbackModel).value.Split(",");
            if (data.Length >= 1) Title.text = data[0];
            if (data.Length >= 2) endpoint = data[1];
            View.SetActive(data.Length >= 2);
            canvasGroup.interactable = data.Length >= 2;
            InputField.text = "";
            UpdateButton();
        }

        public void UpdateButton()
        {
            SubmitButton.interactable = !string.IsNullOrWhiteSpace(InputField.text);
        }

        public virtual void StartSubmit()
        {
            StartCoroutine(Submit());
        }

        IEnumerator Submit()
        {
            canvasGroup.interactable = false;
            using (UnityWebRequest www = UnityWebRequest.Post(endpoint, GetForm()))
            {
                yield return www.SendWebRequest();

                switch (www.result)
                {
                    case UnityWebRequest.Result.ConnectionError:
                    case UnityWebRequest.Result.DataProcessingError:
                        Failed("[BasicTextFeedbackController] Error: " + www.error);
                        break;
                    case UnityWebRequest.Result.ProtocolError:
                        Failed("[BasicTextFeedbackController] HTTP Error: " + www.error);
                        break;
                    case UnityWebRequest.Result.Success:
                        Debug.Log("[BasicTextFeedbackController] Received: " + www.downloadHandler.text);
                        Submitted();
                        break;
                }
            }
        }

        protected virtual WWWForm GetForm()
        {
            WWWForm form = new WWWForm();
            form.AddField("subject", Title.text);
            form.AddField("value", InputField.text);
            return form;
        }

        protected virtual void Failed(string error)
        {
            canvasGroup.interactable = true;
        }

        protected virtual void Submitted()
        {
            View.SetActive(false);
        }
    }
}
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using Logger = Logging.Runtime.Logger;

namespace outrealxr.holomod.Runtime
{
    public class RemoteScoreModel : WebRequestHandler
    {

        public static RemoteScoreModel instance;

        private void Awake()
        {
            instance = this;
        }

        public void Execute(double score)
        {
            SetUrl(WorldSettings.instance.GetFormattedScoreUpdateHost());
            StartCoroutine(SendPostRequest(score));
        }

        private IEnumerator SendPostRequest(double score)
        {
            var formData = new List<IMultipartFormSection>();

            formData.Add(new MultipartFormDataSection("score", score.ToString()));

            var request = UnityWebRequest.Post(url, formData);
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                var jObj = JObject.Parse(request.downloadHandler.text);

                foreach (var outputVar in outputVars)
                    if (jObj.ContainsKey(outputVar.gameObject.name))
                        outputVar.Deserialize(jObj.GetValue(outputVar.gameObject.name));

                OnSuccess?.Invoke();
            }
            else
            {
                Logger.LogWarning("Failed to receive data from the server.", this);
                OnFail?.Invoke();
            }
        }
    }
}
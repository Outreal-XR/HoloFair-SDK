using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Networking;
using Logger = Logging.Runtime.Logger;

namespace outrealxr.holomod.Runtime
{
    public class PostRequestHandler : WebRequestHandler
    {
        [SerializeField] private List<SerializedVar> inputVars = new ();

        public void Execute() => StartCoroutine(SendGetRequest());

        private IEnumerator SendGetRequest() {
            var form = new WWWForm();

            foreach (var inputVar in inputVars) 
                form.AddField(inputVar.gameObject.name, inputVar.Serialize().ToString());

            var request = UnityWebRequest.Post(url, form);
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success) {
                var jObj = JObject.Parse(request.downloadHandler.text);

                foreach (var outputVar in outputVars)
                    if (jObj.ContainsKey(outputVar.gameObject.name)) 
                        outputVar.Deserialize(jObj.GetValue(outputVar.gameObject.name));
                
                OnSuccess?.Invoke();
            } else {
                Logger.LogWarning("Failed to receive data from the server.", this);  
                OnFail?.Invoke();
            }
        }
    }
}
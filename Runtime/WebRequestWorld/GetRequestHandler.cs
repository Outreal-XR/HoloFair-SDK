using System.Collections;
using Newtonsoft.Json.Linq;
using UnityEngine.Networking;
using Logger = Logging.Runtime.Logger;

namespace outrealxr.holomod.Runtime
{
    public class GetRequestHandler : WebRequestHandler
    {
        public void Execute() => StartCoroutine(SendGetRequest());

        private IEnumerator SendGetRequest() {
            var request = new UnityWebRequest(url);

            print(url);
            
            request.downloadHandler = new DownloadHandlerBuffer();
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success) {
                var jObj = JObject.Parse(request.downloadHandler.text);

                foreach (var outputVar in outputVars)
                    if (jObj.ContainsKey(outputVar.gameObject.name)) 
                        outputVar.Deserialize(jObj.GetValue(outputVar.gameObject.name));
                
                OnSuccess?.Invoke();
            } else {
                Logger.LogWarning($"Failed to receive data from the server. Error: {request.error}", this);  
                OnFail?.Invoke();
            }
        }
    }
}

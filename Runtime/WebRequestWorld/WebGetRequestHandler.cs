using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Networking;
using Logger = Logging.Runtime.Logger;

namespace outrealxr.holomod.Runtime
{
    public class WebGetRequestHandler : MonoBehaviour
    {
        [SerializeField] private string url;
        [SerializeField] private List<Parser> parsers = new ();

        public void SetUrl(string url) => this.url = url;

        public void Execute() => StartCoroutine(SendGetRequest());

        private IEnumerator SendGetRequest() {
            var request = new UnityWebRequest(url);

            request.downloadHandler = new DownloadHandlerBuffer();
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success) {
                var jObj = JObject.Parse(request.downloadHandler.text);

                foreach (var parser in parsers)
                    if (jObj.ContainsKey(parser.gameObject.name)) 
                        parser.SetValue(jObj.GetValue(parser.gameObject.name));
            } else {
                Logger.LogWarning("Failed to receive data from the server.", this);  
            }
        }
    }
}
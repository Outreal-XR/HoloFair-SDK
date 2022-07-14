using System.Collections;
using Newtonsoft.Json.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;

namespace outrealxr.holomod
{
    public class VSGetRequester : MonoBehaviour
    {
        [SerializeField] private Variables variables;

        [SerializeField, Space(10)] private string url;
        [SerializeField] private bool getOnStart;
        
        private void Start() {
            if (getOnStart)
                SendGetRequest();
        }

        public void SendGetRequest() {
            var jObj = new JObject();

            foreach (var declaration in variables.declarations) {
                if(declaration.value is int or string or bool or float or double)
                    jObj.Add(declaration.name, JToken.FromObject(declaration.value));
            }
            
            Debug.Log($"<b>[VSGetRequester]</b> Sending the following JSON as get request to {url}: \n {jObj}");

            StartCoroutine(GetRequest(jObj));
        }

        private IEnumerator GetRequest(JObject json) {
            var request = UnityWebRequest.Post(url, json.ToString());
            
            
            yield return null;
        }
    }
}
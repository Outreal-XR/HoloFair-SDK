using System.Collections;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Networking;

namespace outrealxr.holomod
{
    public class HttpQuestionModel : BasicQuestionModel
    {
        [SerializeField] private string getURL;
        [SerializeField] private string postURL;
        
        public override void GetData() {
            var uri = $"{getURL}/?groupNumber={groupId}&guid={guid}";    
            StartCoroutine(SendGetRequest(uri));
        }

        private IEnumerator SendGetRequest(string uri) {
            var request = new UnityWebRequest(uri);

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success) {
                var jObj = JObject.Parse(request.downloadHandler.text);

                question = jObj.GetValue("question").Value<string>();
                
                var optionsArray = jObj.GetValue("options").Value<JArray>();
                options = new Option[optionsArray.Count];
                for (var i = 0; i < options.Length; i++) {
                    options[i].ID = optionsArray[i].Value<JObject>().GetValue("id").Value<int>();
                    options[i].OptionText = optionsArray[i].Value<JObject>().GetValue("option").Value<string>();
                }

                if (jObj.GetValue("visible").Value<bool>()) 
                    OnAvailable?.Invoke();
                else 
                    OnUnavailable?.Invoke();
                
                if (string.IsNullOrEmpty(jObj.GetValue("available").Value<string>()))
                    AvailableText(jObj.GetValue("available").Value<string>());

            } else {
                Debug.LogWarning($"[HTTPQuestionModel] Get request error: {request.error}");
            }
        }

        protected override void AvailableText(string text) {
            Debug.Log(text);
        }

        public override void SelectOption(int i, float timeTaken) {
            StartCoroutine(SendPostRequest(i, timeTaken));
        }

        private IEnumerator SendPostRequest(int optionId, float timeTaken) {
            var postJObj = new JObject();
            postJObj.Add("uuid", JToken.FromObject(uuId));
            postJObj.Add("guid", JToken.FromObject(guid));
            postJObj.Add("optionid", JToken.FromObject(optionId));
            postJObj.Add("timeTaken", JToken.FromObject(timeTaken));
            
            var request = UnityWebRequest.Post(postURL, postJObj.ToString());

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success) {
                var jObj = JObject.Parse(request.downloadHandler.text);
                
                if (jObj.GetValue("correct").Value<bool>())
                    OnCorrectAnswer?.Invoke();
                else
                    OnIncorrectAnswer?.Invoke();
                
                view.Write();
            } else {
                Debug.LogWarning($"[HTTPQuestionModel] Post request error: {request.error}");
            }
        }
    }   
}
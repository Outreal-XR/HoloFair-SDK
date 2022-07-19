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
            var uri = $"{getURL}?uuid={uuId}&guid={guid}&group={groupId}";    
            print($"[HTTPQuestionModel] URI is {uri}");
            StartCoroutine(SendGetRequest(uri));
        }

        private IEnumerator SendGetRequest(string uri) {
            var request = new UnityWebRequest(uri);

            request.downloadHandler = new DownloadHandlerBuffer();
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success) {
                print($"[HTTPQuestionModel] the response data: {request.downloadHandler.text}");
                var jObj = JObject.Parse(request.downloadHandler.text);
                print($"[HTTPQuestionModel] the json: {jObj}");

                if (!guid.Equals(jObj.GetValue("guid").Value<string>())) {
                    Debug.LogWarning($"[HTTPQuestionModel] Something is wrong. This user received response for guid:{jObj.GetValue("guid").Value<int>()} while waiting for guid:{guid}");
                    OnUnavailable?.Invoke();
                    yield break;
                }
                
                question = jObj.GetValue("question").Value<string>();
                questionId = jObj.GetValue("id").Value<int>();
                
                var optionsArray = jObj.GetValue("options").Value<JArray>();
                options = new Option[optionsArray.Count];
                for (var i = 0; i < options.Length; i++) {
                    options[i].ID = optionsArray[i].Value<JObject>().GetValue("id").Value<int>();
                    options[i].OptionText = optionsArray[i].Value<JObject>().GetValue("option").Value<string>();
                }
                
                OnAvailable?.Invoke();
            } else {
                Debug.LogWarning($"[HTTPQuestionModel] Get request error: {request.error}");
                OnUnavailable?.Invoke();
            }
        }

        public override void SelectOption(int i, float timeTaken) {
            StartCoroutine(SendPostRequest(i, timeTaken));
        }

        private IEnumerator SendPostRequest(int optionId, float timeTaken) {
            var postJObj = new JObject();
            postJObj.Add("uuid", JToken.FromObject(uuId));
            postJObj.Add("questionid", JToken.FromObject(questionId));
            postJObj.Add("optionid", JToken.FromObject(optionId));
            postJObj.Add("time", JToken.FromObject(timeTaken));
            
            var request = UnityWebRequest.Post(postURL, postJObj.ToString());

            request.downloadHandler = new DownloadHandlerBuffer();
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success) {
                var jObj = JObject.Parse(request.downloadHandler.text);

                if (jObj.GetValue("id").Value<int>() != questionId) {
                    Debug.LogWarning($"[HTTPQuestionModel] Something is wrong. This user received response for id:{jObj.GetValue("id").Value<int>()} while waiting for id:{questionId}");
                    OnIncorrectAnswer?.Invoke();
                    yield break;
                }

                if (jObj.GetValue("correct").Value<int>() == 1)
                    OnCorrectAnswer?.Invoke();
                else
                    OnIncorrectAnswer?.Invoke();
                
                view.Write();
            } else {
                OnIncorrectAnswer?.Invoke();
                Debug.LogWarning($"[HTTPQuestionModel] Post request error: {request.error}");
            }
        }
    }   
}
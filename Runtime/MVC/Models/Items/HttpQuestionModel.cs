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
            Debug.Log($"[HttpQuestionModel] URI for get: {uri}");
            StartCoroutine(SendGetRequest(uri));
        }

        private IEnumerator SendGetRequest(string uri) {
            var request = new UnityWebRequest(uri);

            request.downloadHandler = new DownloadHandlerBuffer();
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success) {
                var jObj = JObject.Parse(request.downloadHandler.text);

                if (!guid.Equals(jObj.GetValue("guid").Value<string>())) {
                    Debug.LogWarning($"[HTTPQuestionModel] Something is wrong. This user received response for guid:{jObj.GetValue("guid").Value<int>()} while waiting for guid:{guid}");
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
                switch (request.error) {
                    case "204":
                        Debug.LogWarning($"[HTTPQuestionModel] No content");
                        OnFakeQuestion?.Invoke();
                        break;
                    case "404":
                        Debug.LogWarning($"[HTTPQuestionModel] Not found");
                        OnUnavailable?.Invoke();
                        break;
                }
            }
        }

        public override void SelectOption(int i, float timeTaken) {
            StartCoroutine(SendPostRequest(i, timeTaken));
        }

        private IEnumerator SendPostRequest(int optionId, float timeTaken) {
            var form = new WWWForm();
            form.AddField("uuid", uuId);
            form.AddField("questionid", questionId);
            form.AddField("optionid", optionId);
            form.AddField("time", timeTaken.ToString());
            
            var request = UnityWebRequest.Post(postURL, form);
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success) {
                var jObj = JObject.Parse(request.downloadHandler.text);

                var result = jObj.GetValue("result").Value<JObject>();

                if (result.GetValue("correct").Value<int>() == 1)
                    OnCorrectAnswer?.Invoke();
                else
                    OnIncorrectAnswer?.Invoke();
            } else {
                OnIncorrectAnswer?.Invoke();
                Debug.LogWarning($"[HTTPQuestionModel] Result: {request.downloadHandler.text}. Post request error: {request.error}");
            }
        }
    }   
}
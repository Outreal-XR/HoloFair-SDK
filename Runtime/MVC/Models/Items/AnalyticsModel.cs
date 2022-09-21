using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace outrealxr.holomod
{
    public class AnalyticsModel : Model
    {
        public override string type => "analytics";

        [SerializeField] private string resource;
        [TextArea(2,5)]
        public string tags;
       
        IEnumerator SendData(int action, string resource)
        {
            WWWForm form = new WWWForm();
            form.AddField("guid", guid);
            form.AddField("action", action);
            form.AddField("resource", resource);
            form.AddField("tags", tags);
            form.AddField("room", (view.controller as BasicAnalyticsController).RoomName);

            using (UnityWebRequest www = UnityWebRequest.Post(WorldSettings.instance.GetFormattedInteractionsHistoryPath(), form))
            {
                yield return www.SendWebRequest();

                if (www.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log($"[AnalyticsModel] Analytics failed: {WorldSettings.instance.GetFormattedInteractionsHistoryPath()}. form: {form}. Response: {www.downloadHandler.text}");
                }
                else if(Application.platform == RuntimePlatform.WindowsEditor)
                {
                    Debug.Log($"[AnalyticsModel] Analytics submitted: {WorldSettings.instance.GetFormattedInteractionsHistoryPath()}. form: {form}");
                }
            }
        }

        public void RecordImmediate()
        {
            StartCoroutine(SendData(0, resource));
        }

        public void RecordStart()
        {
            StartCoroutine(SendData(1, resource));
        }

        public void RecordEnd()
        {
            StartCoroutine(SendData(2, resource));
        }

        internal void RecordImmediateWithCustomResource(string resource)
        {
            StartCoroutine(SendData(0, resource));
        }

        internal void RecordStartWithCustomResource(string resource)
        {
            StartCoroutine(SendData(1, resource));
        }

        internal void RecordEndWithCustomResource(string resource)
        {
            StartCoroutine(SendData(2, resource));
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace com.outrealxr.holomod
{
    public abstract class Analytics : MonoBehaviour
    {
        [TextArea(3,5)]
        public string apiPath;
        public static Analytics instance;

        IEnumerator SendData(View view, int action, string resource)
        {
            WWWForm form = new WWWForm();
            form.AddField("guid", view.ViewId);
            form.AddField("action", action);
            form.AddField("resource", resource);
            form.AddField("tags", view.tags);
            form.AddField("room", GetRoomName());

            using (UnityWebRequest www = UnityWebRequest.Post(GetFormattedAPIPath(), form))
            {
                yield return www.SendWebRequest();

                if (www.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError($"[Analytics] Analytics failed: {GetFormattedAPIPath()}. form: {form}. Response: {www.downloadHandler.text}");
                }
                else if (Application.platform == RuntimePlatform.WindowsEditor)
                {
                    Debug.Log($"[Analytics] Analytics submitted: {GetFormattedAPIPath()}. form: {form}");
                }
            }
        }

        public void RecordImmediate(View view, string resource)
        {
            StartCoroutine(SendData(view, 0, resource));
        }

        public void RecordStart(View view, string resource)
        {
            StartCoroutine(SendData(view, 1, resource));
        }

        public void RecordEnd(View view, string resource)
        {
            StartCoroutine(SendData(view, 2, resource));
        }

        public abstract string GetRoomName();
        public virtual string GetFormattedAPIPath()
        {
            return apiPath;
        }
    }
}
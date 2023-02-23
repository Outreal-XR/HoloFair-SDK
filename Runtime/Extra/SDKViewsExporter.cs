using UnityEngine;
using SaG.GuidReferences;
using Newtonsoft.Json.Linq;

namespace com.outrealxr.holomod
{
    public class SDKViewsExporter : MonoBehaviour
    {
        private void Start()
        {
            Export();    
        }

        public void Export()
        {
            JObject json = new();
            string roomName = "my room"; //FindObjectOfType<SFSConnection>().Connection.LastJoinedRoom.Name
            json.Add("room", roomName);

            JObject viewsJSON = new();
            var views = FindObjectsOfType<View>();

            foreach (var view in views)
            {
                var guid = view.GetComponent<GuidComponent>();

                if (guid && !viewsJSON.ContainsKey(guid.GetStringGuid())) 
                    viewsJSON.Add(guid.GetStringGuid(), view.gameObject.name);
            }

            json.Add("views", viewsJSON);

            Debug.Log("json" + json.ToString());
        }

        private bool IsViewHasValue(View view)
        {
            if (!view.GetType().IsGenericType)
                return false;

            var intValue = view as ViewT<int>;
            if (intValue is not null)
                return intValue.GetValue != 0;

            var stringValue = view as ViewT<string>;
            if (stringValue is not null)
                return !string.IsNullOrEmpty(stringValue.GetValue);

            var doubleValue = view as ViewT<double>;
            if (doubleValue is not null)
                return doubleValue.GetValue != 0;

            return false;
        }
    }
}
using System.Collections;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Networking;

namespace outrealxr.holomod
{
    public class AnalyticsModel : Model
    {
        public override string type => "analytics";

        [SerializeField] private string postUrl;
        
        public void SendData (string guid, int action) {
            var form = new WWWForm();
            form.AddField("uuid", (view.controller as BasicAnalyticsController).UuId);
            form.AddField("guid", guid);
            form.AddField("action", action);
            form.AddField("room", (view.controller as BasicAnalyticsController).RoomName);
            
            UnityWebRequest.Post(postUrl, form).SendWebRequest();
        }
    }
}
using UnityEngine;
using UnityEngine.Networking;

namespace outrealxr.holomod
{
    public class AnalyticsModel : Model
    {
        public override string type => "analytics";

        [SerializeField] private string postUrl;
        
        void SendData (int action) {
            var form = new WWWForm();

            form.AddField("guid", guid);
            form.AddField("action", action);
            form.AddField("room", (view.controller as BasicAnalyticsController).RoomName);
            
            UnityWebRequest.Post(WorldSettings.instance.GetFormattedInteractionsHistoryPath(), form).SendWebRequest();
        }

        public void RecordImmediate()
        {
            SendData(0);
        }

        public void RecordStart()
        {
            SendData(1);
        }

        public void RecordEnd()
        {
            SendData(2);
        }
    }
}
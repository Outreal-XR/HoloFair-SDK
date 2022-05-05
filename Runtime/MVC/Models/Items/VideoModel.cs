using Newtonsoft.Json.Linq;
using UnityEngine;

namespace outrealxr.holomod
{
    public class VideoModel : ImageModel
    {

        public enum Control
        {
            OnClick,
            OnTrigger
        }

        public bool IsLive, IsSynced;
        public Control control;
        public int materialIndex;
        [TextArea(2,5)]
        public string instructionsToCrossTheBarierToWatchInFullScreen = "Cross the barier to click and watch the video in full screen mode";
        [Tooltip("Must be UTC")]
        public double startTimestamp;
        public Texture2D thumbnail;
        public GameObject loadingVisual;

        public override string type => "video";

        public override void FromJObject(JObject data)
        {
            base.FromJObject(data);
            if (data.ContainsKey("IsLive")) IsLive = data.GetValue("IsLive").Value<bool>();
            else Debug.Log("[VideoProvider] Missing IsLive key");
            if (data.ContainsKey("IsSynced")) IsSynced = data.GetValue("IsSynced").Value<bool>();
            else Debug.Log("[VideoProvider] Missing IsSynced key");
            if (data.ContainsKey("startTimestamp")) startTimestamp = data.GetValue("startTimestamp").Value<double>();
            else Debug.Log("[VideoProvider] Missing startTimestamp key");
        }

        public override JObject ToJObject()
        {
            JObject data = base.ToJObject();
            data.Add(new JProperty("IsLive", IsLive));
            data.Add(new JProperty("IsSynced", IsSynced));
            data.Add(new JProperty("startTimestamp", startTimestamp));
            return data;
        }
    }
}
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace outrealxr.holomod
{
    public class VideoProvider : ImageProvider
    {

        public enum Control
        {
            OnClick,
            OnTrigger
        }

        public bool IsLive, IsSynced;
        public Control control;
        [TextArea(2,5)]
        public string instructionsToCrossTheBarierToWatchInFullScreen = "Cross the barier to click and watch the video in full screen mode";
        [Tooltip("Must be UTC")]
        public double startTimestamp;

        public override string ModKey => "video";

        public override string providerType => GetType().Name;

        public override void FromJObject(JObject data)
        {
            base.FromJObject(data);
            IsLive = data.GetValue("IsLive").Value<bool>();
            IsSynced = data.GetValue("IsSynced").Value<bool>();
            startTimestamp = data.GetValue("startTimestamp").Value<double>();
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
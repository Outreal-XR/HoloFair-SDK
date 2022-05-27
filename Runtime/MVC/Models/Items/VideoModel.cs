using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace outrealxr.holomod
{
    public class VideoModel : ImageModel
    {
        public enum Control
        {
            OnClick,
            OnTrigger
        }

        public enum State
        {
            Stopped,
            Playing,
            Loading,
            Error
        }

        [Header("Network Settings")]
        public bool IsSynced;
        [Tooltip("Must be UTC")]
        public double startTimestamp;

        [Header("Local Settings")]
        [Tooltip("Changes automatically whenever value ends with m3u8")]
        public bool IsLive;
        [MinMax(0, 15)]
        public Vector2 thumbnailRange;
        public State state;
        public Control control;
        public GameObject loadingVisual;
        [TextArea(2, 5)]
        public string instructionsToCrossTheBarierToWatchInFullScreen = "Cross the barier to click and watch the video in full screen mode";

        public override string type => "video";

        public void SetState(State state)
        {
            this.state = state;
        }

        public override void FromJObject(JObject data)
        {
            base.FromJObject(data);
            IsLive = value.EndsWith("m3u8");
            if (data.ContainsKey("IsSynced")) IsSynced = data.GetValue("IsSynced").Value<bool>();
            else Debug.Log("[VideoProvider] Missing IsSynced key");
            if (data.ContainsKey("startTimestamp")) startTimestamp = data.GetValue("startTimestamp").Value<double>();
            else Debug.Log("[VideoProvider] Missing startTimestamp key");
            if (!IsLive) VideoThumbnailQueue.instance.Queue(((BasicVideoView)view).networkImage, Random.Range(thumbnailRange.x, thumbnailRange.y));
        }

        public override JObject ToJObject()
        {
            JObject data = base.ToJObject();
            data.Add(new JProperty("IsSynced", IsSynced));
            data.Add(new JProperty("startTimestamp", startTimestamp));
            return data;
        }
    }
}
using com.outrealxr.networkimages;
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

        public enum State
        {
            Stopped,
            Playing,
            Loading,
            Error
        }

        public enum ThumbnailBehavior
        {
            Generate,
            Download,
            None
        }

        [Header("Network Settings")]
        public bool IsSynced;
        [Tooltip("Must be UTC")]
        public double startTimestamp;

        [Header("Local Settings")]
        public ThumbnailBehavior thumbnailBehavior;
        public State state;
        public Control control;
        [Tooltip("Changes automatically whenever value ends with m3u8")]
        public bool IsLive;
        public Vector2 thumbnailRange = new Vector2(0, 15);
        public string textureProperty = "_BaseMap";

        [Header("Extras")]
        public GameObject loadingVisual;
        [TextArea(2, 5)]
        public string instructionsToCrossTheBarierToWatchInFullScreen = "Cross the barier to click and watch the video in full screen mode";

        public override string type => "video";

        private void Start()
        {
            RefreshThumbnail();
        }

        public void SetState(State state)
        {
            this.state = state;
            if (state == State.Playing) VideoPlayerController.instance.SetSourceModel(this);
            else if(state == State.Stopped) VideoPlayerController.instance.SetSourceModel(null);
        }

        public void SetFullScreen(bool val)
        {
            VideoPlayerController.instance.SetFullScreen(val);
        }

        public override void FromJObject(JObject data)
        {
            base.FromJObject(data);
            IsLive = value.EndsWith("m3u8");
            if (data.ContainsKey("IsSynced")) IsSynced = data.GetValue("IsSynced").Value<bool>();
            else Debug.Log("[VideoProvider] Missing IsSynced key");
            if (data.ContainsKey("startTimestamp")) startTimestamp = data.GetValue("startTimestamp").Value<double>();
            else Debug.Log("[VideoProvider] Missing startTimestamp key");
            RefreshThumbnail();
        }

        public void RefreshThumbnail()
        {
            if (thumbnailBehavior == ThumbnailBehavior.Download)
            {
                if (value.Contains(".mp4")) ((BasicVideoView)view).networkImage.SetAndEnqueue(value.Replace(".mp4", ".jpg"));
                else if (value.Contains(".m3u8")) ((BasicVideoView)view).networkImage.SetAndEnqueue(value.Replace(".m3u8", ".jpg"));
            }
            else if (!IsLive && thumbnailBehavior == ThumbnailBehavior.Generate)
                throw new System.NotImplementedException("Took too much to make it possible. Please use ThumbnailBehavior.Download instead");
        }

        public MeshRenderer GetMeshRenderer()
        {
            return ((NetworkImageMeshRenderer)((BasicVideoView)view).networkImage).target;
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
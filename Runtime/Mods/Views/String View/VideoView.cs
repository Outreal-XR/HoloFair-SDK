using System;
using System.Collections;
using com.outrealxr.networkimages;
using UnityEngine;
using UnityEngine.Events;

namespace com.outrealxr.holomod
{
    public class VideoView : LinkView
    {
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
            None,
            Custom
        }

        public override string Tags => "video";

        [SerializeField] [Header("Local Settings")]
        private ThumbnailBehavior _thumbnailBehavior;
        private State _state;

        [SerializeField] [Tooltip("Whether the video should open full screen whenever user tries to watch it.")]
        private bool _isFullScreenOnPlay;

        private bool _isLive;
        
        [Tooltip("Used whenever thumbnail behavior is custom"), SerializeField]
        private ImageView _imageView;
        
        [SerializeField] private string _textureProperty = "_BaseMap";

        public bool IsLive => _isLive;
        public bool IsFullScreenOnPlay => _isFullScreenOnPlay;

        public string TextureProperty => _textureProperty;

        public override void Edit() {
            JavaScriptMessageReciever.instance.StartEdit(new VideoParser(this));
        }

        public void SetState(State state) {
            _state = state;
            if (state == State.Playing) {
                OnVideoStarted?.Invoke();
                Analytics.instance.RecordStart(this, GetValue);
            } else if (state == State.Stopped) {
                OnVideoEnded?.Invoke();
                RefreshThumbnail();
                Analytics.instance.RecordEnd(this, GetValue);
            }
        }
        
        [SerializeField] private UnityEvent OnVideoStarted;
        [SerializeField] private UnityEvent OnVideoEnded;

        private Action<bool> _onFullscreen;
        public void RegisterOnFullScreen(Action<bool> action) => _onFullscreen = action;
        public void SetFullScreen(bool val) => _onFullscreen?.Invoke(val);

        private Action<string> _onPlay;
        public void RegisterOnPlay(Action<string> action) => _onPlay = action;
        public void Play() {
            SetSource();
            _onPlay?.Invoke(GetValue);
        }

        private Action _onStop;
        public void RegisterOnStop(Action action) => _onStop = action;
        public void Stop() => _onStop?.Invoke();

        private Action<string> _onToggle;
        public void RegisterOnToggle(Action<string> action) => _onToggle = action;
        public void Toggle() {
            SetSource();
            _onToggle?.Invoke(GetValue);
        }

        private Action<VideoView> _onSetSource;
        public void RegisterOnSetSource(Action<VideoView> action) => _onSetSource = action;
        public void SetSource() => _onSetSource?.Invoke(this);

        public override void SetValue(string value) {
            _value = value;
            _isLive = value.EndsWith("m3u8");
            
            if (_state == State.Playing) {
                Stop();
                StartCoroutine(Replay());
            }
            else
            {
                RefreshThumbnail();
            }
        }
        
        private IEnumerator Replay() {
            yield return new WaitForEndOfFrame();
            Play();
        }
        
        public void RefreshThumbnail() {
            if (_imageView == null) {
                Debug.LogError($"[VideoView] The image view field of \"{gameObject.name}\" is null!");
                return;
            }

            if (!IsLive && _thumbnailBehavior == ThumbnailBehavior.Generate)
                Debug.LogWarning("Took too much to make it possible. Please use ThumbnailBehavior.Download or ThumbnailBehavior.Custom instead");
            else if (_thumbnailBehavior == ThumbnailBehavior.Download)
            {
                if (GetValue.Contains(".mp4")) _imageView.SetValue(GetValue.Replace(".mp4", ".jpg"));
                else if (GetValue.Contains(".m3u8")) _imageView.SetValue(GetValue.Replace(".m3u8", ".jpg"));
            }
            else if (_thumbnailBehavior == ThumbnailBehavior.Custom)
                _imageView.LoadImage();
        }
        
        public MeshRenderer GetMeshRenderer() => ((NetworkImageMeshRenderer)_imageView.NetworkImage).target;
        public Material GetSharedMaterial() => ((NetworkImageMeshRendererShared)_imageView.NetworkImage).GetMaterial();
        public bool IsTargetAvailable() => (NetworkImageMeshRenderer)_imageView.NetworkImage != null;
        public bool IsTargetShared() => _imageView.NetworkImage.GetType() == typeof(NetworkImageMeshRendererShared);
    }
}
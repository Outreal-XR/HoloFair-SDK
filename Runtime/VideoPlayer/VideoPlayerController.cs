using UnityEngine;

namespace com.outrealxr.holomod
{
    public abstract class VideoPlayerController : MonoBehaviour
    {
        [SerializeField] protected VideoView _view;

        public static VideoPlayerController instance;

        private void Awake()
        {
            instance = this;
        }

        public abstract void Prepare(VideoPlayerView view);

        public virtual void SetSource(VideoView view)
        {
            if(view == null) Stop();
            else
            {
                Play();
                VideoPlayerView.instance.ApplyVolume();
            }
            this._view = view;
        }

        public abstract void SetFullScreen(bool val);

        public abstract void StartSeek();

        public abstract void EndSeek(float progressAmount);

        public abstract void Play();

        public abstract void SetVolume(float val);

        public abstract void Pause();

        public abstract void Stop();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace outrealxr.holomod
{
    public abstract class VideoPlayerController : MonoBehaviour
    {
        public VideoModel sourceModel;

        public static VideoPlayerController instance;

        private void Awake()
        {
            instance = this;
        }

        public abstract void Prepare(VideoPlayerView view);

        public virtual void SetSourceModel(VideoModel sourceModel)
        {
            if(sourceModel == null) Stop();
            else
            {
                Play();
                VideoPlayerView.instance.ApplyVolume();
            }
            this.sourceModel = sourceModel;
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
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

        public virtual void SetSourceModel(VideoModel sourceModel)
        {
            this.sourceModel = sourceModel;
            VideoPlayerModel.instance.SetIsActive(sourceModel != null);
            if(sourceModel == null) Stop();
            else
            {
                Play();
                VideoPlayerView.instance.ApplyVolume();
            }
        }

        public virtual void SetFullScreen(bool val)
        {
            if (sourceModel)
                VideoPlayerModel.instance.SetFullScreen(val);
        }

        public virtual void StartSeek()
        {
            if(sourceModel)
                VideoPlayerModel.instance.SetIsSeek(true);
        }

        public virtual void EndSeek(float progressAmount)
        {
            if (sourceModel)
                VideoPlayerModel.instance.SetIsSeek(false);
        }

        public virtual void Play()
        {
            if (sourceModel)
                VideoPlayerModel.instance.SetIsPlaying(true);
        }

        public virtual void SetVolume(float val)
        {
            throw new System.NotImplementedException("There is no logic for SetVolume in video player controller");
        }

        public virtual void Pause()
        {
            if (sourceModel)
                VideoPlayerModel.instance.SetIsPaused(true);
        }

        public virtual void Stop()
        {
            if (sourceModel)
            {
                if (sourceModel.control == VideoModel.Control.OnTrigger && VideoPlayerModel.instance.fullScreen)
                {
                    SetFullScreen(false);
                    return;
                }
                VideoPlayerModel.instance.SetIsPlaying(false);
                VideoPlayerModel.instance.SetIsActive(false);
            }
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace outrealxr.holomod
{
    public class VideoPlayerModel : MonoBehaviour
    {
        public enum State
        {
            Idle,
            isPlaying,
            isPaused,
            isLoading,
            isSeekingStarted,
            isSeekingEnded,
            Error
        }

        public State state;
        internal bool fullScreen;
        internal bool isLive;
        internal float progress, length;
        internal string error;

        public static VideoPlayerModel instance;

        private void Awake()
        {
            instance = this;
            SetIsActive(false);
            UpdateUI();
        }

        public void ToggleFullScreen()
        {
            SetFullScreen(!fullScreen);
        }

        public void SetFullScreen(bool val)
        {
            fullScreen = val;
            UpdateUI();
        }

        internal void SetIsActive(bool val)
        {
            if (!val) state = State.Idle;
        }

        internal void SetIsLive(bool val)
        {
            isLive = val;
            UpdateUI();
        }

        internal void SetIsSeek(bool val)
        {
            state = val ? State.isSeekingStarted : State.isSeekingEnded;
            UpdateUI();
        }

        internal void SetIsPaused(bool val)
        {
            if (val) state = State.isPaused;
            UpdateUI();
        }

        internal void SetIsPlaying(bool val)
        {
            if (val) state = State.isPlaying;
            UpdateUI();
            VideoPlayerView.instance.RefreshTimeUntilCanvasFadesNow();
            VideoPlayerView.instance.SetControlsCanvasGroup(true);
        }

        internal void SetError(string val)
        {
            state = State.Error;
            error = val;
            UpdateUI();
        }

        void UpdateUI()
        {
            VideoPlayerView.instance.UpdateUI(this);
        }
    }
}
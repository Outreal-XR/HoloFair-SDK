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
        public bool fullScreen;
        public bool isLive;
        public float progress, length;
        internal string error;

        public static VideoPlayerModel instance;

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            SetState(State.Idle);
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

        public void SetLength(float val)
        {
            length = val;
            UpdateUI();
        }

        public void SetIsLive(bool val)
        {
            isLive = val;
            UpdateUI();
            VideoPlayerView.instance.SetProgressSliderInteraction(!val);
        }

        public void ShowControls()
        {
            VideoPlayerView.instance.RefreshTimeUntilCanvasFadesNow();
            VideoPlayerView.instance.SetControlsCanvasGroup(true);
        }

        public void SetState(State state)
        {
            this.state = state;
            Debug.Log($"[VideoPlayerModel] this.state = {this.state}");
            UpdateUI();
        }

        public void SetError(string val)
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
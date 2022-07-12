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
        internal bool isLive;
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
        }

        public void ShowControls()
        {
            VideoPlayerView.instance.RefreshTimeUntilCanvasFadesNow();
            VideoPlayerView.instance.SetControlsCanvasGroup(true);
        }

        public void SetState(State state)
        {
            this.state = state;
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
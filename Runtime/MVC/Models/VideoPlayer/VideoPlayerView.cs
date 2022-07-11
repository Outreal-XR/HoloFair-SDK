using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace outrealxr.holomod
{
    public class VideoPlayerView : MonoBehaviour
    {
        public CanvasGroup controlsCanvasGroup;
        float controlsCanvasGroupAlphaTarget;
        
        public float controlsCanvasGroupAnimationSpeed = 2;
        public float timeUntilCanvasFades = 5;
        float timeUntilCanvasFadesNow = 0;
        public UnityEngine.UI.Slider progressAmount, volumeAmount;
        public TMPro.TextMeshProUGUI elapsedText, lengthText, errorText;
        public GameObject playButton, pauseButton, maximizeButton, minimizeButton, videoDisplay, videoPlayer, loading, liveItem, errorItem;
        bool autoHide = true;
        public static VideoPlayerView instance;

        private void Awake()
        {
            instance = this;
            volumeAmount.value = PlayerPrefs.GetFloat("VideoPlayerVolume", 1);
            VideoPlayerController.instance.Prepare(this);
        }

        public void SetAutoHide(bool val)
        {
            autoHide = val;
            if (!val) RefreshTimeUntilCanvasFadesNow();
        }

        public void ToggleControlsCanvasGroup()
        {
            SetControlsCanvasGroup(!controlsCanvasGroup.interactable);
        }

        public void SetControlsCanvasGroup(bool val)
        {
            controlsCanvasGroup.interactable = val;
            controlsCanvasGroupAlphaTarget = controlsCanvasGroup.interactable ? 1 : 0;
        }

        public void ToggleFullScreen()
        {
            SetFullScreen(!VideoPlayerModel.instance.fullScreen);
        }

        public void SetFullScreen(bool val)
        {
            VideoPlayerModel.instance.SetFullScreen(val);
            RefreshTimeUntilCanvasFadesNow();
            SetControlsCanvasGroup(true);
        }

        public void RefreshTimeUntilCanvasFadesNow()
        {
            timeUntilCanvasFadesNow = timeUntilCanvasFades;
        }

        private void Update()
        {
            controlsCanvasGroup.alpha = Mathf.Lerp(controlsCanvasGroup.alpha, controlsCanvasGroupAlphaTarget, Time.deltaTime * controlsCanvasGroupAnimationSpeed);
            if(timeUntilCanvasFadesNow > 0 && autoHide && VideoPlayerModel.instance.fullScreen)
            {
                timeUntilCanvasFadesNow -= Time.deltaTime;
                if(timeUntilCanvasFadesNow <= 0)
                    SetControlsCanvasGroup(false);
            }
        }

        public void ApplyVolume()
        {
            VideoPlayerController.instance.SetVolume(volumeAmount.value);
            PlayerPrefs.SetFloat("VideoPlayerVolume", volumeAmount.value);
        }

        public void SetProgress(float val, float length)
        {
            if (val == float.PositiveInfinity) elapsedText.text = "...";
            else
            {
                progressAmount.SetValueWithoutNotify(val);
                TimeSpan t = TimeSpan.FromSeconds(val * length);
                elapsedText.text = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
            }
        }

        public void StartSeek()
        {
            VideoPlayerController.instance.StartSeek();
        }

        public void EndSeek()
        {
            VideoPlayerController.instance.EndSeek(progressAmount.value);
        }

        public void Play()
        {
            VideoPlayerController.instance.Play();
            RefreshTimeUntilCanvasFadesNow();
            SetControlsCanvasGroup(true);
        }

        public void Pause()
        {
            VideoPlayerController.instance.Pause();
            RefreshTimeUntilCanvasFadesNow();
            SetControlsCanvasGroup(true);
        }

        public void Stop()
        {
            VideoPlayerController.instance.Stop();
        }

        internal void UpdateUI(VideoPlayerModel model)
        {
            progressAmount.interactable = !model.isLive;
            if (model.state != VideoPlayerModel.State.Error)
                loading.SetActive(model.state == VideoPlayerModel.State.isLoading || model.state == VideoPlayerModel.State.isSeekingEnded);
            videoPlayer.SetActive(model.state != VideoPlayerModel.State.Idle);
            if (model.state == VideoPlayerModel.State.isPaused || model.state == VideoPlayerModel.State.isPlaying)
            {
                playButton.SetActive(model.state == VideoPlayerModel.State.isPaused);
                pauseButton.SetActive(model.state == VideoPlayerModel.State.isPlaying);
            }

            maximizeButton.SetActive(!model.fullScreen);
            minimizeButton.SetActive(model.fullScreen);

            liveItem.SetActive(model.isLive);
            errorItem.SetActive(model.state == VideoPlayerModel.State.Error);
            errorText.text = $"Please, try to click on a video again. Error: {model.error}";
            if (model.length == float.PositiveInfinity) lengthText.text = "Live";
            else
            {
                TimeSpan t = TimeSpan.FromSeconds(model.length);
                lengthText.text = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
            }
            videoDisplay.SetActive(model.fullScreen);
        }

        public void UpdateProgress(VideoPlayerModel model)
        {
            SetProgress(model.progress, model.length);
        }
    }
}
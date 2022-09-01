using System;
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
        public GameObject playButton, pauseButton, maximizeButton, minimizeButton, videoDisplayBackground, videoDisplay, progressbar, timespan, videoPlayer, loading, liveItem, errorItem;
        bool autoHide = true;
        public static VideoPlayerView instance;

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
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
            videoDisplayBackground.SetActive(val);
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

        public void SetProgressSliderInteraction(bool val)
        {
            progressAmount.interactable = val;
        }

        internal void UpdateUI(VideoPlayerModel model)
        {
            if (model.state != VideoPlayerModel.State.Error)
                loading.SetActive(model.state == VideoPlayerModel.State.isLoading || model.state == VideoPlayerModel.State.isSeekingEnded);
            if (model.state == VideoPlayerModel.State.isPaused || model.state == VideoPlayerModel.State.isPlaying)
            {
                playButton.SetActive(model.state == VideoPlayerModel.State.isPaused);
                pauseButton.SetActive(model.state == VideoPlayerModel.State.isPlaying);
            }

            videoPlayer.SetActive(model.fullScreen);

            maximizeButton.SetActive(!model.fullScreen);
            minimizeButton.SetActive(model.fullScreen);

            liveItem.SetActive(model.isLive);
            timespan.SetActive(!model.isLive);
            progressbar.SetActive(!model.isLive);
            
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
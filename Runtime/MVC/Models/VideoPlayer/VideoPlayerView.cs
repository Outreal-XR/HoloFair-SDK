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
        public UnityEngine.UI.RawImage videoDisplay;
        public UnityEngine.UI.Slider progressAmount, volumeAmount;
        public UnityEngine.UI.RawImage PrimaryPlayButton, SecondaryPlayButton, PrimaryPauseButton, SecondayPauseButton;
        public TMPro.TextMeshProUGUI elapsedText, lengthText, errorText;
        public GameObject videoPlayer, primaryLoading, liveItem, errorItem;
        bool autoHide = true;
        public static VideoPlayerView instance;

        private void Awake()
        {
            instance = this;
            volumeAmount.value = PlayerPrefs.GetFloat("VideoPlayerVolume", 1);
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

        public void RefreshTimeUntilCanvasFadesNow()
        {
            timeUntilCanvasFadesNow = timeUntilCanvasFades;
        }

        private void Update()
        {
            controlsCanvasGroup.alpha = Mathf.Lerp(controlsCanvasGroup.alpha, controlsCanvasGroupAlphaTarget, Time.deltaTime * controlsCanvasGroupAnimationSpeed);
            if(timeUntilCanvasFadesNow > 0 && autoHide)
            {
                timeUntilCanvasFadesNow -= Time.deltaTime;
                if(timeUntilCanvasFadesNow <= 0)
                    SetControlsCanvasGroup(false);
            }
        }

        public void StartSeek()
        {
            VideoPlayerController.instance.StartSeek();
        }

        public void ApplyVolume()
        {
            VideoPlayerController.instance.SetVolume(volumeAmount.value);
            PlayerPrefs.SetFloat("VideoPlayerVolume", volumeAmount.value);
        }

        public void SetProgress(float val, float length)
        {
            progressAmount.SetValueWithoutNotify(val);
            TimeSpan t = TimeSpan.FromSeconds(val * length);
            elapsedText.text = string.Format("{0:D2}h:{1:D2}m:{2:D2}s", t.Hours, t.Minutes, t.Seconds);
        }

        public void EndSeek()
        {
            VideoPlayerController.instance.EndSeek(progressAmount.value);
        }

        public void Play()
        {
            VideoPlayerController.instance.Play();
        }

        public void Pause()
        {
            VideoPlayerController.instance.Pause();
        }

        public void Stop()
        {
            VideoPlayerController.instance.Stop();
        }

        internal void UpdateUI(VideoPlayerModel model)
        {
            if (model.state != VideoPlayerModel.State.Error)
                primaryLoading.SetActive(model.state == VideoPlayerModel.State.isLoading || model.state == VideoPlayerModel.State.isSeekingEnded);
            videoPlayer.SetActive(model.state != VideoPlayerModel.State.Idle);
            if (videoPlayer.activeInHierarchy)
            {
                TimeSpan t = TimeSpan.FromSeconds(model.length);
                if (model.state == VideoPlayerModel.State.isPaused || model.state == VideoPlayerModel.State.isPlaying)
                {
                    PrimaryPlayButton.gameObject.SetActive(model.state == VideoPlayerModel.State.isPaused);
                    SecondaryPlayButton.gameObject.SetActive(PrimaryPlayButton.gameObject.activeInHierarchy);
                    PrimaryPauseButton.gameObject.SetActive(model.state == VideoPlayerModel.State.isPlaying);
                    SecondayPauseButton.gameObject.SetActive(PrimaryPauseButton.gameObject.activeInHierarchy);
                }
                
                liveItem.SetActive(model.isLive);
                errorText.gameObject.SetActive(model.state == VideoPlayerModel.State.Error);
                errorText.text = $"Please, try to click on a video again. Error: {model.error}";
                lengthText.text = string.Format("{0:D2}h:{1:D2}m:{2:D2}s", t.Hours, t.Minutes, t.Seconds);
            }
        }

        internal void UpdateProgress(VideoPlayerModel model)
        {
            SetProgress(model.progress, model.length);
        }
    }
}
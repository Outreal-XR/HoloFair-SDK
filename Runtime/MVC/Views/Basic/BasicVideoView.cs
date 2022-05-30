using UnityEngine;

namespace outrealxr.holomod
{
    public class BasicVideoView : BasicImageView
    {
        [Tooltip("Assigned automatically on start after world init")]
        BasicVideosController basicVideosController;

        private void Start()
        {
            basicVideosController = (BasicVideosController)controller;
            if (basicVideosController == null) Debug.LogWarning($"[BasicVideoView] There is no video controller for {gameObject.name}");
            else basicVideosController.SetModel(model);
        }

        public void Play()
        {
            basicVideosController.Play();
        }

        public void Stop()
        {
            basicVideosController.Stop();
        }
    }
}
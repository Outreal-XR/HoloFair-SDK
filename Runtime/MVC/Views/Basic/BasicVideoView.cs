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
        }

        public void Play()
        {
            if (basicVideosController == null) Debug.LogWarning($"[BasicVideoView] There is no video controller for {gameObject.name}");
            else
            {
                basicVideosController.SetModel(model);
                basicVideosController.Play();
            }
        }

        /// <summary>
        /// Call this after play to switch full screen mode
        /// </summary>
        /// <param name="val"></param>
        public void SetFullScreen(bool val)
        {
            basicVideosController.SetFullScreen(val);
        }

        public void Stop()
        {
            basicVideosController.Stop();
        }
    }
}
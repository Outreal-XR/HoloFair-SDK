using UnityEngine;

namespace outrealxr.holomod
{
    public class BasicVideoView : BasicImageView
    {
        [Tooltip("Assigned automatically on start after world init")]
        BasicVideosController basicVideosController;

        public void TogglePlay()
        {
            if (!CheckForController()) return;
            
            basicVideosController = (BasicVideosController)controller;
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
            if (!CheckForController()) return;

            basicVideosController.SetFullScreen(val);
        }

        public void Stop()
        {
            if (!CheckForController()) return;

            basicVideosController.Stop();
        }
    }
}
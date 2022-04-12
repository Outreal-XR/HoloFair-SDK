using UnityEngine;
using UnityEngine.Events;

namespace outrealxr.holomod
{
    public class LongInteractionHandler : MonoBehaviour
    {
        [Tooltip("In seconds.")]
        public float holdDuration = 0.5f;
        public float currentTime = 0f;
        
        public UnityEvent OnLongRelease;

        private void Update() {
            if (isHeld)
                currentTime += Time.deltaTime;
        }
        
        private bool isHeld = false;
        public void StartTimer() {
            isHeld = true;

            if (currentTime > holdDuration) StopTimer();
        }
        
        public void StopTimer() {
            if (currentTime > holdDuration) {
                OnLongRelease?.Invoke();
            }

            isHeld = false;
            currentTime = 0;
        }
        
    }
}
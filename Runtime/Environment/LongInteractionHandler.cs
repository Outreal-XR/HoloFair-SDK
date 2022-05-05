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
            
            if (currentTime > holdDuration) StopTimer();
        }
        
        private bool isHeld = false;
        public void StartTimer() {
            isHeld = true;
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
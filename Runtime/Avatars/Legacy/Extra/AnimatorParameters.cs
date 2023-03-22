using UnityEngine;

namespace com.outrealxr.avatars
{
    public class AnimatorParameters : MonoBehaviour
    {

        public enum TimeType
        {
            fixedDeltaTime,
            deltaTime
        }

        public string SpeedParameter = "Speed";
        public string DirectionParameter = "Strafe";
        public float AnimSpeedMultiplier = 1;
        public float LerpSpeed = 25f;
        public TimeType timeType;
        [SerializeField] Animator animator = null;
        Vector3 previousPosition = Vector3.zero;

        private void Awake()
        {
            animator = gameObject.GetComponent<Animator>();
        }

        void Update() {
            if (timeType == TimeType.deltaTime) UpdateAnimation(Time.deltaTime);
        }

        void FixedUpdate() {
            if (timeType == TimeType.fixedDeltaTime) UpdateAnimation(Time.fixedDeltaTime);
        }

        void UpdateAnimation(float delta)
        {
            if (animator != null)
            {
                Vector3 displacement = transform.position - previousPosition;
                Vector3 forward = transform.forward;
                Vector3 right = transform.right;

                float speed = AnimSpeedMultiplier * Vector3.Dot(displacement, forward) / delta;
                float direction = AnimSpeedMultiplier * Vector3.Dot(displacement, right) / delta;
                animator.SetFloat(SpeedParameter, Mathf.Lerp(animator.GetFloat(SpeedParameter), speed, LerpSpeed * delta));
                animator.SetFloat(DirectionParameter, Mathf.Lerp(animator.GetFloat(DirectionParameter), direction, LerpSpeed * delta));
            }
            previousPosition = transform.position;
        }

        private void OnEnable() {
            animator.SetFloat(SpeedParameter, 0);
            animator.SetFloat(DirectionParameter, 0);
        }
    }
}
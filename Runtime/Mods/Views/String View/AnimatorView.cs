using System.Collections;
using UnityEngine;

namespace com.outrealxr.holomod
{
    public class AnimatorView : StringView
    {
        [Header("Local variables")]
        public bool loop;
        public string normalizedTimeParameterName = "progress";
        public double startTime;
        public int layerIndex;
        public float elapsedTime;
        public float animationLength;
        public Animator animator;


        protected override void Start() {
            base.Start();
            startTime = UniversalTime.Now;
        }

        public override void SetValue(string value, Vector3 position) {
            base.SetValue(value, position);
            animator.Play(value);
            startTime = UniversalTime.Now;
            StartCoroutine(UpdateAnimationLength());
        }

        private IEnumerator UpdateAnimationLength()
        {
            yield return new WaitForFixedUpdate();
            var current = animator.GetCurrentAnimatorStateInfo(layerIndex);
            animationLength = current.length;
            LateUpdate();
        }

        private void LateUpdate()
        {
            if (loop) elapsedTime = ((float)(UniversalTime.Now - startTime)) % animationLength;
            else elapsedTime = Mathf.Clamp((float)(UniversalTime.Now - startTime), 0f, animationLength);
            if (animationLength > 0)
                animator.SetFloat(normalizedTimeParameterName, elapsedTime / animationLength);
        }
    }
}

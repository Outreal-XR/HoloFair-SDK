using System.Collections;
using UnityEngine;

namespace com.outrealxr.holomod
{
    public class AnimatorView : StringView
    {
        [Header("Local variables")]
        [SerializeField] private bool _loop;
        [SerializeField] private string _normalizedTimeParameterName = "progress";
        private double _startTime;
        [SerializeField] private int _layerIndex;
        public float elapsedTime;
        public float animationLength;
        [SerializeField] private Animator _animator;


        public override string Tags => "animator";

        protected override void Start() {
            base.Start();
            _startTime = UniversalTime.Now;
        }

        public override void SetValue(string value) {
            base.SetValue(value);

            if (!_animator) {
                Debug.LogError($"[AnimatorView] The animator field of \"{gameObject.name}\" is null!");
                return;
            }

            _animator.Play(value);
            _startTime = UniversalTime.Now;
            StartCoroutine(UpdateAnimationLength());
        }

        private IEnumerator UpdateAnimationLength()
        {
            if (!_animator) {
                Debug.LogError($"[AnimatorView] The animator field of \"{gameObject.name}\" is null!");
                yield break;
            }
            yield return new WaitForFixedUpdate();
            var current = _animator.GetCurrentAnimatorStateInfo(_layerIndex);
            animationLength = current.length;
            LateUpdate();
        }

        private void LateUpdate()
        {
            if (!_animator) {
                Debug.LogError($"[AnimatorView] The animator field of \"{gameObject.name}\" is null!");
                return;
            }
            
            if (_loop) elapsedTime = ((float)(UniversalTime.Now - _startTime)) % animationLength;
            else elapsedTime = Mathf.Clamp((float)(UniversalTime.Now - _startTime), 0f, animationLength);
            if (animationLength > 0)
                _animator.SetFloat(_normalizedTimeParameterName, elapsedTime / animationLength);
        }
    }
}

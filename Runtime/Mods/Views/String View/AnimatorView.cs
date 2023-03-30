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
        private float _elapsedTime;
        private float _animationLength;
        [SerializeField] private Animator _animator;


        public override string Tags => "animator";

        protected override void Start() {
            base.Start();
            _startTime = UniversalTime.SecondsNow;
        }

        public override void SetValue(string value) {
            base.SetValue(value);

            if (!_animator) {
                Debug.LogError($"[AnimatorView] The animator field of \"{gameObject.name}\" is null!");
                return;
            }

            _animator.Play(value);
            _startTime = UniversalTime.SecondsNow;
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
            _animationLength = current.length;
            LateUpdate();
        }

        private void LateUpdate()
        {
            if (!_animator) {
                Debug.LogError($"[AnimatorView] The animator field of \"{gameObject.name}\" is null!");
                return;
            }
            
            if (_loop) _elapsedTime = ((float)(UniversalTime.SecondsNow - _startTime)) % _animationLength;
            else _elapsedTime = Mathf.Clamp((float)(UniversalTime.SecondsNow - _startTime), 0f, _animationLength);
            if (_animationLength > 0)
                _animator.SetFloat(_normalizedTimeParameterName, _elapsedTime / _animationLength);
        }
    }
}

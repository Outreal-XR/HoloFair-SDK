using System;
using GLTFast;
using UnityEngine;

namespace com.outrealxr.avatars.revised
{
    public class AvatarOwner : MonoBehaviour
    {
        public enum State
        {
            None,
            Queued,
            Loading,
            Set
        }

        [Space(20), SerializeField] private GameObject _loading, _queue, _placeholder;
        [SerializeField] private UnityEngine.Events.UnityEvent _onReveal, _onConceal;
        
        [field: SerializeField] public string Src { get; private set; } = "ybot basic";
        private GameObject _avatar;
        
        private void OnEnable() {
            if (!HasAvatar) {
                SetState(State.None);
                Reveal();
            }
        }

        private void OnDisable() {
            ReleaseAvatar();
        }

        /// <summary>
        /// Intended to be triggered by user input
        /// </summary>
        public void Reveal() {
            if (!HasAvatar) AvatarsQueue.Enqueue(this);
        }

        public void SetSrc(string src) {
            Src = src;
            AvatarsQueue.Enqueue(this);
        }

        public void SetQueued() => SetState(State.Queued);

        public void SetDequeued() => SetState(State.Loading);

        public void SetAvatar(GameObject avatar) {
            if (_avatar) ReleaseAvatar();
            _avatar = avatar;
            if (_avatar) {
                _avatar.transform.parent = transform;
                _avatar.transform.localPosition = Vector3.zero;
                _avatar.transform.localRotation = Quaternion.identity;
            }
            if(!gameObject.activeInHierarchy) ReleaseAvatar();
            SetState(_avatar ? State.Set : State.None);
        }

        private void ReleaseAvatar() {
            if (!HasAvatar) return;

            var gltfAsset = _avatar.GetComponentInChildren<GltfAsset>();
            if (gltfAsset) {
                print("disposed");
                gltfAsset.Dispose();
            }
            
            Destroy(_avatar);
        }
        
        private void SetState(State state)
        {
            _loading.SetActive(state == State.Loading);
            _queue.SetActive(state == State.Queued);
            _placeholder.SetActive(state is State.Queued or State.None);
            
            switch (state) {
                case State.None:
                    _onConceal.Invoke();
                    break;
                case State.Set:
                    _onReveal.Invoke();
                    break;
                case State.Queued:
                    break;
                case State.Loading:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }

        public bool IsVisible => gameObject.activeInHierarchy;
        public bool HasAvatar => _avatar != null;
    }
}
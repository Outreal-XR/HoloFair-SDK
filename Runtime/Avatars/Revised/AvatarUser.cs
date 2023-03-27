using System;
using UnityEngine;
using State = com.outrealxr.avatars.revised.AvatarModel.State;

namespace com.outrealxr.avatars.revised
{
    public class AvatarUser : MonoBehaviour
    {
        private GameObject _loading, _queue, _placeholder;
        private UnityEngine.Events.UnityEvent _onReveal, _onConceal;

        void OnEnable()
        {
            SetState(State.None);
            Reveal();
        }

        public void SetState(AvatarModel.State state)
        {
            _loading.SetActive(state == State.Loading);
            _queue.SetActive(state == State.Queued);
            _placeholder.SetActive(state == State.None);
            
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

        /// <summary>
        /// Intended to be triggered by user input
        /// </summary>
        public void Reveal() {
            throw new NotImplementedException();
        }
    }
}
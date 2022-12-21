using UnityEngine;
using UnityEngine.Events;

namespace com.outrealxr.holomod
{
    public class UTCTimeView : DoubleView
    {
        [SerializeField] private UnityEvent OnBefore;
        [SerializeField] private UnityEvent OnAfter;

        private enum State
        {
            Idle,
            Before,
            After
        }

        [SerializeField] private State _state;

        protected override void Start() {
            base.Start();
            UpdateTheTimeUTC();
        }
        
        void Update() {
            if (GetValue > 0) {
                if (UniversalTime.Now > GetValue && _state != State.After) {
                    OnAfter?.Invoke();
                    _state = State.After;
                } else if (UniversalTime.Now <= GetValue && _state != State.Before) {
                    OnBefore?.Invoke();
                    _state = State.Before;
                }
            }
        }
        
        public void UpdateTheTimeUTC()
        {
            _state = State.Idle;
            double difference = GetValue - UniversalTime.Now;
            if (difference > 0) Debug.Log($"[TimerModel] TimerModel.cs will fire after {difference / 1000}s at {gameObject.name}.");
            else if (difference < 0) Debug.Log($"[TimerModel] It have been {difference / -1000}s since the desired time. Firing  at {gameObject.name}....");
        }
    }
}
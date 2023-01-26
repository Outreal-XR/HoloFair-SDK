using UnityEngine;
using UnityEngine.Events;
using Logger = Logging.Runtime.Logger;

namespace com.outrealxr.holomod
{
    public class TimerView : StringView
    {
        [SerializeField] private UnityEvent OnBefore;
        [SerializeField] private UnityEvent OnDuring;
        [SerializeField] private UnityEvent OnAfter;

        [SerializeField] private double _before;
        [SerializeField] private double _after;
        
        private enum State
        {
            Idle,
            Before,
            During,
            After
        }

        [SerializeField] private State _state;

        protected override void Start() {
            base.Start();
            UpdateTheTimeUTC();
        }

        public override void Edit()
        {
            JavaScriptMessageReciever.instance.StartEdit(new UTCTimerParser(this));
        }

        void Update() {
            if (_before > 0) {
                if (UniversalTime.Now > _after && _state != State.After) {
                    OnAfter?.Invoke();
                    _state = State.After;
                    print("after: " + UniversalTime.Now);
                } else if (UniversalTime.Now <= _before && _state != State.Before) {
                    OnBefore?.Invoke();
                    _state = State.Before;
                    print("before: " + UniversalTime.Now);
                } else if (UniversalTime.Now > _before && UniversalTime.Now < _after && _state != State.During) {
                    OnDuring?.Invoke();   
                    _state = State.During;
                    print("during: " + UniversalTime.Now);
                }
            }
        }

        public override void SetValue(string value) {
            base.SetValue(value);
            UpdateTheTimeUTC();
        }

        public void UpdateTheTimeUTC() {
            var times = GetValue.Split(',');

            if (times.Length != 2) {
                Logger.LogWarning("Given string value is invalid and cannot be parsed.", this);
                return;
            }

            _before = double.Parse(times[0]);
            _after = double.Parse(times[1]);
            
            _state = State.Idle;
        }
    }
}
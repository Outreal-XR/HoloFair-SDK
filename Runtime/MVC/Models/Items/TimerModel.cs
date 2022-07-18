using System;
using UnityEngine;
using UnityEngine.Events;

namespace outrealxr.holomod
{
    public class TimerModel : StringModel
    {
        public override string type => "timer";


        [SerializeField] private UnityEvent OnBefore;
        [SerializeField] private UnityEvent OnAfter;

        enum State
        {
            Idle,
            Before,
            After
        }

        State state = State.Idle;

        public override void Init() {
            SetValue(value);
        }

        public double timeUTC;
        
        void Update() {
            if (timeUTC > 0 && timeUTC <= UniversalTimeModel.Now && state != State.After) {
                OnAfter?.Invoke();
                state = State.After;
            } else {
                OnBefore?.Invoke();
                state = State.Before;
            }
        }

        public override void SetValue(string val) {
            base.SetValue(val);

            if (!double.TryParse(val, out timeUTC)) {
                timeUTC = -1;
                Debug.LogWarning("[TimerModel] The value cannot be parsed. Try to input a new, proper decimal value.");
            } else
            {
                state = State.Idle;
            }
        }
    }
}
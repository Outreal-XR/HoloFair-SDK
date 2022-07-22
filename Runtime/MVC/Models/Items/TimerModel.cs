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
            if (timeUTC > 0)
            {
                if (UniversalTimeModel.Now > timeUTC && state != State.After)
                {
                    OnAfter?.Invoke();
                    state = State.After;
                }
                else if (UniversalTimeModel.Now <= timeUTC && state != State.Before)
                {
                    OnBefore?.Invoke();
                    state = State.Before;
                }
            }
        }

        public void UpdateTheTimeUTC()
        {
            if (!double.TryParse(value, out timeUTC))
            {
                timeUTC = -1;
                Debug.LogWarning($"[TimerModel] The value cannot be parsed. Try to input a new, proper decimal value at {gameObject.name}.");
            }
            else
            {
                state = State.Idle;
                double difference = timeUTC - UniversalTimeModel.Now;
                if (difference > 0) Debug.Log($"[TimerModel] TimerModel.cs will fire after {difference / 1000}s at {gameObject.name}.");
                else if (difference < 0) Debug.Log($"[TimerModel] It have been {difference / -1000}s since the desired time. Firing  at {gameObject.name}....");
            }
        }
    }
}
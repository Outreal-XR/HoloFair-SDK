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

        private void Start() {
            SetValue(value);
        }

        [HideInInspector] public double timeUTC;
        [HideInInspector] public double ServerUTCTimeDifference;
        
        private void Update() {
            double timeNow = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() + ServerUTCTimeDifference;
            if (timeUTC > 0 && timeUTC <= timeNow) {
                OnAfter?.Invoke();
            } else {
                OnBefore?.Invoke();
            }
        }

        public override void SetValue(string val) {
            base.SetValue(val);

            if (!double.TryParse(val, out timeUTC)) {
                timeUTC = -1;
                Debug.LogWarning("[TimerModel] The value cannot be parsed. Try to input a new, proper decimal value.");
            }
        }
    }
}
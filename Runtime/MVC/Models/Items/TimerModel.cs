using UnityEngine;
using UnityEngine.Events;

namespace outrealxr.holomod
{
    public class TimerModel : StringModel
    {
        public override string type => "timer";

        public double timeUTC;
        
        [SerializeField] private UnityEvent OnBefore;
        [SerializeField] private UnityEvent OnAfter;
        private void Update() {
            double timeNow = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
            if (timeUTC > 0 && timeUTC <= timeNow) {
                OnAfter?.Invoke();
            } else if (timeUTC > timeNow) {
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
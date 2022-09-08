using UnityEngine;

namespace outrealxr.holomod.Runtime
{
    public class ScoreModel : Model
    {
        public override string type => "score";

        [SerializeField] private float minScore;
        [SerializeField] private float maxScore;

        [SerializeField, Space(10)] private Stopwatch stopwatch;
        public Stopwatch Stopwatch => stopwatch;
        
        [SerializeField, Space(10), Tooltip("In seconds. Starts count after grace period.")] 
        private float maxTimeForMinScore; //In seconds
        
        [SerializeField, Tooltip("The number of seconds before the timer starts deducting from the score.")] 
        private float gracePeriod; //In seconds

        public float GetScore {
            get {
                if (!stopwatch) return maxScore;

                var time = (float)stopwatch.StopTimer();

                if (time < gracePeriod) return maxScore;
                if (time >= gracePeriod + maxTimeForMinScore) return minScore;

                var interpolation = (time - gracePeriod) / maxTimeForMinScore;
                return Mathf.Lerp(minScore, maxScore, interpolation);
            }
        }
    }
}
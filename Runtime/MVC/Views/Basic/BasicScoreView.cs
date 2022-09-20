using UnityEngine;

namespace outrealxr.holomod.Runtime
{
    public class BasicScoreView : View
    {
        public void StartStopwatch() {
            (model as ScoreModel).Stopwatch.StartTimer();
        }

        public override void Apply() {
            var score = (model as ScoreModel).GetScore;
            (controller as BasicScoreController).AddScore(score);
        }

        public void Save()
        {
            (controller as BasicScoreController).Save();
        }

        public override void Edit() {
            Debug.LogWarning($"[BasicScoreView] Edit function is not implemented. Do not call it.");
        }
    }
}
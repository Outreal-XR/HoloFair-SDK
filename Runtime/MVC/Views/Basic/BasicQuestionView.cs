using UnityEngine;

namespace outrealxr.holomod
{
    public class BasicQuestionView : View
    {
        private double startTime = 0;
        [SerializeField] private GameObject questionUI;

        public override void Apply() {
            startTime = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
            questionUI.SetActive(true);
        }

        public void Answer(int i) {
            var difference = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond - startTime;

            float differenceInSeconds = (float) difference / 1000;

            (model as BasicQuestionModel)?.SelectOption(i, differenceInSeconds);
        }

        public override void Edit() {
            throw new System.NotImplementedException();
        }
    }
}
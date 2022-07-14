namespace outrealxr.holomod
{
    public class BasicQuestionView : View
    {

        private double startTime = 0;
        public override void Apply() {
            startTime = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
        }

        public void Answer(int i) {
            var difference = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond - startTime;

            float differenceInSeconds = (float) difference / 1000;

            (model as BaseQuestionModel)?.SelectOption(i, differenceInSeconds);
        }

        public override void Edit() {
            throw new System.NotImplementedException();
        }
    }
}
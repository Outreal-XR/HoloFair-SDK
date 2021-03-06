using com.outrealxr.networkimages;
using TMPro;
using UnityEngine;

namespace outrealxr.holomod
{
    public class BasicQuestionView : View
    {
        private double startTime = 0;
        [SerializeField] private GameObject questionUI;

        public override void Apply() {
            Debug.Log("[BasicQuestionView] This view has no implementation of Apply");
        }

        public void OpenUI() {
            Debug.Log($"[BasicQuestionView] Opened question of {model.name}");
            
            startTime = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
            questionUI.SetActive(true);
        }

        public void Answer(int i) {
            var difference = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond - startTime;

            float differenceInSeconds = (float) difference / 1000;

            (model as BasicQuestionModel)?.SelectOption(i, differenceInSeconds);
        }

        [SerializeField] private NetworkImageUIImage question;
        public void UpdateQuestionText() {
            question.SetAndEnqueue((model as BasicQuestionModel)?.question);
        }

        public override void Edit() {
            throw new System.NotImplementedException();
        }
    }
}